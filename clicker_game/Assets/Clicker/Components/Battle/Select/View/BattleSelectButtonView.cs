using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using R3;
using Cysharp.Threading.Tasks;
using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class BattleSelectButtonView : MonoBehaviour
    {
        private ScreenPresenter _screenPresenter;
        private EnemyPresenter _enemyPresenter;

        [Inject]
        public void Construct
            (
                ScreenPresenter screenPresenter,
                EnemyPresenter enemyPresenter
            )
        {
            Debug.Log("BattleSelectButtonView : Inject");
            _screenPresenter = screenPresenter;
            _enemyPresenter = enemyPresenter;
        }

        [SerializeField]
        private Button _button;

        private int _enemyID = 0;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            AddListener();
        }

        private void AddListener()
        {
            _button
                .OnClickAsObservable()
                .Subscribe(_ => OnClickButton());
        }

        private void OnClickButton()
        {
            Debug.Log($"enemyID : {_enemyID}");
            _enemyPresenter.BattleSelect(_enemyID);
            _screenPresenter.MoveScreen(AddressableUIType.Battle);
        }

        public void SetEnemyID(int enemyID)
        {
            _enemyID = enemyID;
        }
    }
}
