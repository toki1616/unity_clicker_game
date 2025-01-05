using UnityEngine;
using R3;
using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class ScreenModel
    {
        private ReactiveProperty<AddressableUIType> _addressableUITypeReactiveProperty = new ReactiveProperty<AddressableUIType>(AddressableUIType.Home);
        public ReadOnlyReactiveProperty<AddressableUIType> AddressableUITypeReactiveProperty => _addressableUITypeReactiveProperty;

        public void MoveScreen(AddressableUIType addressableUIType)
        {
            _addressableUITypeReactiveProperty.Value = addressableUIType;
        }
    }
}
