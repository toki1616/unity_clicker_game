using UnityEngine;
using R3;

namespace My.ClickerGame
{
    public class ScreenModel
    {
        private ReactiveProperty<ScreenType> _screenTypeReactiveProperty = new ReactiveProperty<ScreenType>(ScreenType.BattleSelect);
        public ReadOnlyReactiveProperty<ScreenType> ScreenTypeReactiveProperty => _screenTypeReactiveProperty;

        public void MoveScreen(ScreenType screenType)
        {
            _screenTypeReactiveProperty.Value = screenType;
        }
    }
}
