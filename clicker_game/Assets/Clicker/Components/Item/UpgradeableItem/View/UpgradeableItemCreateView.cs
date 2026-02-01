using System;
using UnityEngine;
using My.ClickerGame.Util;
using My.ClickerGame.Ex;
using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class UpgradeableItemCreateView : MonoBehaviour
    {        
        private AddressableManager _addressableManager;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _addressableManager = new AddressableManager(AddressableGroupEnum.UIParts.GetAddressableGroup());
            CreateUpgradeableItemViewAdressable();
        }
        
        private async void CreateUpgradeableItemViewAdressable()
        {
            await _addressableManager.LoadAssetAsync<GameObject>(AddressableUIPartsEnum.UpgradeableItemUI.GetAddressableName(), obj =>
            {
                // ロード成功時の処理
                Debug.Log($"Scene {obj} loaded successfully.");

                foreach (UpgradeableItemType value in Enum.GetValues(typeof(UpgradeableItemType)))
                {
                    GameObject spawnObject = Instantiate(obj, this.transform);
                    spawnObject.GetComponent<UpgradeableItemView>().SetUpgradeableItemType(value);
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
