using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using My.ClickerGame.Util;

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

        //MoveScreen
        public void MoveScreen(ScreenType screenType)
        {
            _screenModel.MoveScreen(screenType);
        }

        public Observable<ScreenType> screenTypeAsObservable => 
            _screenModel.ScreenTypeReactiveProperty
            .Publish()
            .RefCount();
    }
}
