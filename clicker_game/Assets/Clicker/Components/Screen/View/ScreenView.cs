using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using R3;
using Cysharp.Threading.Tasks;
using My.ClickerGame.Util;
using My.ClickerGame.Ex;
using UnityEngine.AddressableAssets;

namespace My.ClickerGame
{
    public class ScreenView : MonoBehaviour
    {
        private ScreenPresenter _screenPresenter;

        [Inject]
        public void Construct
            (
                ScreenPresenter screenPresenter
            )
        {
            Debug.Log("ScreenView : Inject");
            _screenPresenter = screenPresenter;
        }

        private AddressableManager _addressableManager;

        [SerializeField]
        private GameObject _fullScreenPanel;

        [SerializeField]
        private GameObject _safeAreaMainScreenPanel;

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _addressableManager = new AddressableManager("UIGroup");
            AddListener();
        }

        private void AddListener()
        {
            _screenPresenter
                .screenTypeAsObservable
                .Subscribe(_ => MoveScreen(_))
                .AddTo(this);
        }

        private async void MoveScreen(ScreenType screenType)
        {
            await _addressableManager.LoadAssetAsync<GameObject>(screenType.GetAddressableNameFromScreenType(), obj =>
            {
                // ロード成功時の処理
                Debug.Log($"Scene {obj} loaded successfully.");

                switch (screenType.GetScreenSizeFromScreenType())
                {
                    case ScreenSize.Full:
                        {
                            GameObject view = Instantiate(obj, _fullScreenPanel.transform);
                            break;
                        }

                    case ScreenSize.SafeArea:
                        {
                            GameObject view = Instantiate(obj, _safeAreaMainScreenPanel.transform);
                            break;
                        }
                }
            },
            error =>
            {
                // ロード失敗時の処理
                Debug.LogError($"Error loading scene: {error.Message}");
            });
        }
    }
}
