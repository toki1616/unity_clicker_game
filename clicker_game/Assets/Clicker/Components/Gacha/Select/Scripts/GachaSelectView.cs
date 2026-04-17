using System;
using UnityEngine;
using Zenject;

using My.ClickerGame.MyEnum;
using My.ClickerGame.Util;
using My.ClickerGame.Ex;

namespace My.ClickerGame
{
    public class GachaSelectView : MonoBehaviour
    {
        private IInstantiator _instantiator;

        [Inject]
        public void Construct(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        [SerializeField]
        private Transform _buttonContainer;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            CreateSelectButton();
        }
        
        private async void CreateSelectButton()
        {
            var _addressableManager = new AddressableManager(AddressableGroupEnum.UIParts.GetAddressableGroup());

            await _addressableManager.LoadAssetAsync<GameObject>(AddressableUIPartsEnum.GachaSelectButton.GetAddressableName(), obj =>
            {
                // ロード成功時の処理
                Debug.Log($"Scene {obj} loaded successfully.");
                
                foreach (GachaType value in Enum.GetValues(typeof(GachaType)))
                {
                    var buttonView = _instantiator.InstantiatePrefabForComponent<GachaSelectButtonView>(obj, _buttonContainer);
                    buttonView.GetComponent<GachaSelectButtonView>().SetGachaType(value);
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
