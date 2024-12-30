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
    public class BattleTimeLimitView : MonoBehaviour
    {
        private BattlePresenter _battlePresenter;

        [Inject]
        public void Construct
            (
                BattlePresenter battlePresenter
            )
        {
            Debug.Log("BattleTimeLimitView : Inject");
            _battlePresenter = battlePresenter;
        }

        [SerializeField]
        private TextMeshProUGUI _timeLimitTMPro;

        [SerializeField]
        private Slider _timeLimitSlider;

        private float _maxTimeLimit = 0;

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
            _battlePresenter.RemainingTimeObservable.Subscribe(_ => UpdateTimeLimit(_)).AddTo(this);
        }

        private void UpdateTimeLimit(float timeLimit)
        {
            Debug.Log("UpdateSelectEnemy");

            if (_maxTimeLimit == 0)
            {
                _maxTimeLimit = timeLimit;
            }

            SetTimeLimitText(timeLimit);
            SetTimeLimitGauge(timeLimit);
        }

        private void SetTimeLimitText(float timeLimit)
        {
            if (!_timeLimitTMPro) { return; }

            _timeLimitTMPro.text = $"{timeLimit}";
        }

        private void SetTimeLimitGauge(float timeLimit)
        {
            _timeLimitSlider.value = timeLimit / _maxTimeLimit;
        }
    }
}
