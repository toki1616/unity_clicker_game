using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using My.ClickerGame.MyEnum;

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
            //Debug.Log("ScreenPresenter : Inject");
            _screenModel = screenModel;
        }

        //MoveScreen
        public void MoveScreen(AddressableUIType addressableUIType)
        {
            _screenModel.MoveScreen(addressableUIType);
        }

        public Observable<AddressableUIType> screenTypeAsObservable => 
            _screenModel.AddressableUITypeReactiveProperty
            .Publish()
            .RefCount();
    }
}
