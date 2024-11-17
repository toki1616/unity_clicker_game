using UnityEngine;

namespace MyUI
{
    sealed public class SafeAreaAdjusterForOneSide : SafeAreaAdjusterBase
    {
        public enum SafeAreaAlignment
        {
            Left,
            Right,
        }

        [Header("セーフモード")]

        [SerializeField]
        private SafeAreaAlignment _safeAreaAlignment = SafeAreaAlignment.Left;

        [Header("背景")]

        [SerializeField]
        private RectTransform _backImage;

        /// <summary>
        /// 左右のみセーフエリアに入れる
        /// </summary>
        protected override void UpdateSafeArea(ScreenData screenData)
        {
            if (_rectTransform == null)
            {
                return;
            }

            Vector2 anchorMin = _rectTransform.anchorMin;
            Vector2 anchorMax = _rectTransform.anchorMax;

            float safeAreaLeft = screenData.safeArea.xMin / screenData.width;
            float safeAreaRight = screenData.safeArea.xMax / screenData.width;

            switch (_safeAreaAlignment)
            {
                case SafeAreaAlignment.Left:
                    anchorMin.x = safeAreaLeft;
                    anchorMax.x = 1.0f;
                    break;

                case SafeAreaAlignment.Right:
                    anchorMin.x = 0.0f;
                    anchorMax.x = safeAreaRight;
                    break;
            }

            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;

            // 背景は含めたくない場合があるので別処理
            if (_backImage != null)
            {
                Vector2 backgroundAnchorMin = _backImage.anchorMin;
                Vector2 backgroundAnchorMax = _backImage.anchorMax;

                switch (_safeAreaAlignment)
                {
                    case SafeAreaAlignment.Left:
                        backgroundAnchorMin.x = -safeAreaLeft;
                        backgroundAnchorMax.x = safeAreaLeft;
                        break;

                    case SafeAreaAlignment.Right:
                        backgroundAnchorMin.x = safeAreaRight;
                        backgroundAnchorMax.x = 1.0f + (1.0f - safeAreaRight);
                        break;
                }

                _backImage.anchorMin = backgroundAnchorMin;
                _backImage.anchorMax = backgroundAnchorMax;
            }
        }
    }
}
