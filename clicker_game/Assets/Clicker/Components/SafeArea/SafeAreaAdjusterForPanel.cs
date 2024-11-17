using UnityEngine;

namespace MyUI
{
    sealed public class SafeAreaAdjusterForPanel : SafeAreaAdjusterBase
    {
        public enum SafeAreaMode
        {
            None,
            Vertical,
            Horizontal,
            Both
        }

        [Header("セーフモード")]

        [SerializeField]
        private SafeAreaMode _safeAreaMode = SafeAreaMode.Both;

        [Space]
        [Header("背景")]

        [SerializeField]
        private SafeAreaMode _backSafeAreaMode = SafeAreaMode.None;

        [SerializeField]
        private bool _isBackExpansion = false;

        [SerializeField]
        private RectTransform _backImage;

        /// <summary>
        /// セーフエリア内に収めえる
        /// </summary>
        protected override void UpdateSafeArea(ScreenData screenData)
        {
            if (_rectTransform == null)
            {
                return;
            }

            Vector2 anchorMin = screenData.safeArea.position;
            Vector2 anchorMax = screenData.safeArea.position + screenData.safeArea.size;

            anchorMin.x /= screenData.width;
            anchorMin.y /= screenData.height;
            anchorMax.x /= screenData.width;
            anchorMax.y /= screenData.height;

            Vector2 newAnchorMin = _rectTransform.anchorMin;
            Vector2 newAnchorMax = _rectTransform.anchorMax;

            switch (_safeAreaMode)
            {
                case SafeAreaMode.Vertical:
                    newAnchorMin.y = anchorMin.y;
                    newAnchorMax.y = anchorMax.y;
                    break;
                case SafeAreaMode.Horizontal:
                    newAnchorMin.x = anchorMin.x;
                    newAnchorMax.x = anchorMax.x;
                    break;
                case SafeAreaMode.Both:
                    newAnchorMin = anchorMin;
                    newAnchorMax = anchorMax;
                    break;
            }

            _rectTransform.anchorMin = newAnchorMin;
            _rectTransform.anchorMax = newAnchorMax;

            // 背景は含めたくない場合があるので別処理
            if (_backImage != null)
            {
                Vector2 backAnchorMin = _backImage.anchorMin;
                Vector2 backAnchorMax = _backImage.anchorMax;

                if (_isBackExpansion)
                {
                    switch (_backSafeAreaMode)
                    {
                        case SafeAreaMode.Vertical:
                            backAnchorMin.y = 0;
                            backAnchorMax.y = 1;
                            backAnchorMin.x = -0.1f;
                            backAnchorMax.x = 1.1f;
                            break;
                        case SafeAreaMode.Horizontal:
                            backAnchorMin.x = 0;
                            backAnchorMax.x = 1;
                            backAnchorMin.y = -0.1f;
                            backAnchorMax.y = 1.1f;
                            break;
                        case SafeAreaMode.Both:
                            backAnchorMin = new Vector2(-0.1f, -0.1f);
                            backAnchorMax = new Vector2(1.1f, 1.1f);
                            break;
                    }
                }
                else
                {
                    switch (_backSafeAreaMode)
                    {
                        case SafeAreaMode.Vertical:
                            backAnchorMin.y = 0;
                            backAnchorMax.y = 1;
                            backAnchorMin.x = anchorMin.x;
                            backAnchorMax.x = anchorMax.x;
                            break;
                        case SafeAreaMode.Horizontal:
                            backAnchorMin.x = 0;
                            backAnchorMax.x = 1;
                            backAnchorMin.y = anchorMin.y;
                            backAnchorMax.y = anchorMax.y;
                            break;
                        case SafeAreaMode.Both:
                            backAnchorMin = Vector2.zero;
                            backAnchorMax = Vector2.one;
                            break;
                    }
                }

                _backImage.anchorMin = backAnchorMin;
                _backImage.anchorMax = backAnchorMax;
            }
        }
    }
}
