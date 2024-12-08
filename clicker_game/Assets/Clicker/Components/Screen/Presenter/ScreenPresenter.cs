using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

namespace My.ClickerGame
{
    public class ScreenPresenter
    {
        private readonly ScreenModel _screenModel;

        public ScreenPresenter
            (
            ScreenModel screenModel
            )
        {
            Debug.Log("ScreenPresenter : Inject");
            _screenModel = screenModel;
        }

        public void MoveScreen(FooterMenuType footerMenuType)
        {
            _screenModel.MoveScreen(footerMenuType);
        }
    }
}
