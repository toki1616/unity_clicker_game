using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using R3;
using R3.Triggers;
using UnityEngine.EventSystems;

namespace My.ClickerGame
{
    public class BattleTapView : MonoBehaviour
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
            var eventTrigger = this.gameObject.AddComponent<ObservableEventTrigger>();
            // PointerDown
            eventTrigger
                .OnPointerDownAsObservable()
                .Subscribe(pointerEventData => OnPointerDown(pointerEventData))
                .AddTo(this);
        }

        private void OnPointerDown(PointerEventData pointerEventData)
        {
            //Debug.Log(pointerEventData.position);
            _battlePresenter.OnTapBattleDamage();
        }
    }
}
