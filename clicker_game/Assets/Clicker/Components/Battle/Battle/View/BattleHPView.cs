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
            //Debug.Log("BattleHPView : Inject");
            _battlePresenter = battlePresenter;
        }

        [SerializeField]
        private TextMeshProUGUI _hpTMPro;

        [SerializeField]
        private Slider _hpSlider;

        private int _maxHP = 0;

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
            SetHP(enemy.HitPoint);
        }

        private void SetHP(int hp)
        {
            if (_maxHP == 0)
            {
                _maxHP = hp;
            }

            SetHPText(hp);
            SetHPGauge(hp);
        }

        private void SetHPText(int hp)
        {
            if (!_hpTMPro) { return; }

            _hpTMPro.text = $"{hp}";
        }

        private void SetHPGauge(int hp)
        {
            float hpPer = (float)hp / (float)_maxHP;
            _hpSlider.value = hpPer;
        }
    }
}
