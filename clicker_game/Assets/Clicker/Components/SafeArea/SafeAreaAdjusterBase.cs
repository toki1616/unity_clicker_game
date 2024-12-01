using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MyUI
{
    abstract public class SafeAreaAdjusterBase : MonoBehaviour
    {
        protected RectTransform _rectTransform;
        protected ScreenData _lastScreenData;

        private bool _isSyncScreen;

        /// <summary>
        /// 破壊時
        /// </summary>
        private void OnDestroy()
        {
            _isSyncScreen = false;
        }

        /// <summary>
        /// ScreenData
        /// </summary>
        protected struct ScreenData
        {
            public int width;
            public int height;
            public Rect safeArea;

            public override readonly bool Equals(object obj)
            {
                if (obj is not ScreenData)
                {
                    return false;
                }

                ScreenData other = (ScreenData)obj;
                return width == other.width && height == other.height && safeArea == other.safeArea;
            }

            /// <summary>
            /// GetHashCode
            /// </summary>
            public override readonly int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// 起動時
        /// </summary>
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            ScreenData screenData = GetScreenData();
            UpdateSafeArea(screenData);
            SetLastScreenData(screenData);

#if UNITY_EDITOR
            SnckScreenAsync().Forget();
#endif
        }

        /// <summary>
        /// スクリーンデータの取得
        /// </summary>
        protected ScreenData GetScreenData()
        {
            ScreenData screenData = new ScreenData
            {
                width = Screen.width,
                height = Screen.height,
                safeArea = Screen.safeArea
            };
            return screenData;
        }

        /// <summary>
        /// セーフエリアに入れる
        /// </summary>
        protected virtual void UpdateSafeArea(ScreenData screenData)
        {
            // 継承先で実装
        }

        /// <summary>
        /// ラストデータの更新
        /// </summary>
        private void SetLastScreenData(ScreenData screenData)
        {
            _lastScreenData = screenData;
        }

#if UNITY_EDITOR
        /// <summary>
        /// 非同期で画面同期
        /// </summary>
        private async UniTaskVoid SnckScreenAsync()
        {
            _isSyncScreen = true;
            while (_isSyncScreen)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);

                ScreenData screenData = GetScreenData();
                if (!screenData.Equals(_lastScreenData))
                {
                    UpdateSafeArea(screenData);
                    SetLastScreenData(screenData);
                }
            }
        }
#endif
    }
}
