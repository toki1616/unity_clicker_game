using System.Collections.Generic;
using UnityEngine;
using Zenject;
using R3;
using Cysharp.Threading.Tasks;
using My.ClickerGame.Util;
using My.ClickerGame.Ex;
using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class BattleSelectCreateButtonView : MonoBehaviour
    {
        private EnemyPresenter _enemyPresenter;

        [Inject]
        public void Construct
            (
                EnemyPresenter enemyPresenter
            )
        {
            _enemyPresenter = enemyPresenter;
        }

        [SerializeField]
        private GameObject _parentObject;

        private AddressableManager _addressableManager;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _addressableManager = new AddressableManager(AddressableGroupEnum.UIParts.GetAddressableGroup());
            CreateBattleSelectButton();
        }

        private async void CreateBattleSelectButton()
        {
            List<Enemy> enemyList = _enemyPresenter.GetEnemyList();
            Debug.Log(AddressableGroupEnum.UIParts.GetAddressableGroup());
            Debug.Log(AddressableUIPartsEnum.BattleSelectButton.GetAddressableName());

            await _addressableManager.LoadAssetAsync<GameObject>(AddressableUIPartsEnum.BattleSelectButton.GetAddressableName(), obj =>
            {
                // ロード成功時の処理
                Debug.Log($"Scene {obj} loaded successfully.");
                GameObject view = Instantiate(obj, _parentObject.transform);
            },
            error =>
            {
                // ロード失敗時の処理
                Debug.LogError($"Error loading scene: {error.Message}");
            });
        }
    }
}
