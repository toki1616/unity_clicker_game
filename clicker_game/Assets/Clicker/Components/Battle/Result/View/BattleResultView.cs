using UnityEngine;
using Zenject;

using My.ClickerGame.Util;
using My.ClickerGame.Ex;
using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class BattleResultView : MonoBehaviour
    {
        private BattlePresenter _battlePresenter;

        [Inject]
        public void Construct
            (
                BattlePresenter battlePresenter
            )
        {
            //Debug.Log("BattleResultTapView : Inject");
            _battlePresenter = battlePresenter;
        }

        [SerializeField]
        private GameObject _parentObj;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateDropItems();
        }

        private async void CreateDropItems()
        {
            var dropItems = _battlePresenter.GetDropItems();
            var _addressableManager = new AddressableManager(AddressableGroupEnum.UIParts.GetAddressableGroup());

            await _addressableManager.LoadAssetAsync<GameObject>(AddressableUIPartsEnum.ResultDropItemUI.GetAddressableName(), obj =>
            {
                // ロード成功時の処理
                Debug.Log($"Scene {obj} loaded successfully.");

                foreach (var dropItem in dropItems)
                {
                    GameObject view = Instantiate(obj, _parentObj.transform);
                    view.GetComponent<DropItemView>().SetDropItem(dropItem);
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
