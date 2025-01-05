using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;
using R3;
using R3.Triggers;

namespace My.ClickerGame
{
    public class BattleEndView : MonoBehaviour
    {
        private BattlePresenter _battlePresenter;

        [Inject]
        public void Construct
            (
                BattlePresenter battlePresenter
            )
        {
            Debug.Log("BattleEndView : Inject");
            _battlePresenter = battlePresenter;
        }

        [SerializeField]
        private GameObject successView;

        [SerializeField]
        private GameObject failureView;

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
            _battlePresenter.IsGameEndSuccessObservable.Subscribe(_ => EndViewActive(_)).AddTo(this);
        }

        private void EndViewActive(bool isSucceed)
        {
            SuccessViewActiveChange(isSucceed);
            FailureViewActiveChange(!isSucceed);
        }

        private void SuccessViewActiveChange(bool isActive)
        {
            successView.SetActive(isActive);
        }

        private void FailureViewActiveChange(bool isActive)
        {
            failureView.SetActive(isActive);
        }
    }
}
