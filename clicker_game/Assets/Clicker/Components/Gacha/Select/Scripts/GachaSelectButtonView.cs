using UnityEngine;
using UnityEngine.UI;
using Zenject;
using R3;
using R3.Triggers;
using TMPro;
using My.ClickerGame.Ex;
using My.ClickerGame.MyEnum;
using ModestTree;

namespace My.ClickerGame
{
    public class GachaSelectButtonView : MonoBehaviour
    {
        private ScreenPresenter _screenPresenter;

        [Inject]
        public void Construct
            (
                ScreenPresenter screenPresenter
            )
        {
            //Debug.Log("FooterMenuButtonView : Inject");
            _screenPresenter = screenPresenter;
        }

        [SerializeField]
        private Button _moveButton;

        [SerializeField]
        private TextMeshProUGUI _typeTMPro;

        private GachaType _gachaType;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        public void SetGachaType(GachaType gachaType)
        {
            _gachaType = gachaType;
            _typeTMPro.text = $"{gachaType.GetGachaName()}";
        }

        private void Initialize()
        {
            AddListener();
        }

        private void AddListener()
        {
            _moveButton
                .OnClickAsObservable()
                .Subscribe(_ => OnClickMove());
        }

        private void OnClickMove()
        {
            //_screenPresenter.MoveScreen((AddressableUIType)_footerMenuType);
            Debug.Log($"onClick : {_gachaType}");
        }
    }
}
