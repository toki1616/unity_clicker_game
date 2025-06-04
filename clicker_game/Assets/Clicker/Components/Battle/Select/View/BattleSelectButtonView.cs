using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using R3;
using Cysharp.Threading.Tasks;
using TMPro;
using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class BattleSelectButtonView : MonoBehaviour
    {
        private ScreenPresenter _screenPresenter;
        private BattlePresenter _battlePresenter;

        [Inject]
        public void Construct
            (
                ScreenPresenter screenPresenter,
                BattlePresenter battlePresenter
            )
        {
            Debug.Log("BattleSelectButtonView : Inject");
            _screenPresenter = screenPresenter;
            _battlePresenter = battlePresenter;
        }

        [SerializeField]
        private Button _button;

        [SerializeField]
        private TextMeshProUGUI _nameTMpro;

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
            _battlePresenter.BattleSelect(_enemyID);
            _screenPresenter.MoveScreen(AddressableUIType.Battle);
        }

        public void SetEnemy(Enemy enemy)
        {
            _enemyID = enemy.ID;
            _nameTMpro.text = enemy.Name;
        }
    }
}
