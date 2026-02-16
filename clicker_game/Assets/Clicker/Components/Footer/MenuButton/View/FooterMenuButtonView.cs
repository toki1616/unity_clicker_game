using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using R3;
using R3.Triggers;
using ObservableCollections;
using TMPro;
using My.ClickerGame.Ex;
using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class FooterMenuButtonView : MonoBehaviour
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

        private FooterMenuType _footerMenuType;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        public void SetFooterMenuType(FooterMenuType footerMenuType)
        {
            _footerMenuType = footerMenuType;
            _typeTMPro.text = $"{footerMenuType.GetFooterMenuName()}";
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
            _screenPresenter.MoveScreen((AddressableUIType)_footerMenuType);
        }
    }
}
