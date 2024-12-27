using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using R3;
using R3.Triggers;
using UnityEngine.EventSystems;

namespace My.ClickerGame
{
    public class BattleHPView : MonoBehaviour
    {
        private BattlePresenter _battlePresenter;

        [Inject]
        public void Construct
            (
                BattlePresenter battlePresenter
            )
        {
            Debug.Log("BattleHPView : Inject");
            _battlePresenter = battlePresenter;
        }

        [SerializeField]
        private TextMeshProUGUI _hpTMPro;

        [SerializeField]
        private Slider _hpSlider;

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
            _battlePresenter.SelectEnemyObservable.Subscribe(_ => UpdateSelectEnemy(_)).AddTo(this);
            _battlePresenter.SelectEnemyForceNotify();
        }

        private void UpdateSelectEnemy(Enemy enemy)
        {
            Debug.Log("UpdateSelectEnemy");
            SetHPText(enemy.HitPoint);
        }

        private void SetHPText(int hp)
        {
            if (!_hpTMPro) { return; }

            _hpTMPro.text = $"{hp}";
        }
    }
}
