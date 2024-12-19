using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.ClickerGame.MyEnum;
using My.ClickerGame.Const;

namespace My.ClickerGame.Ex
{
    public static class AddressableEx
    {
        public static string GetAddressableGroup(this AddressableGroupEnum addressableGroupEnum)
        {
            switch (addressableGroupEnum)
            {
                case AddressableGroupEnum.UI:
                    return AddressableConst.uiGroup;

                case AddressableGroupEnum.UIParts:
                    return AddressableConst.uiPartsGroup;

                default:
                    return AddressableConst.uiGroup;
            }
        }

        public static string GetAddressableName(this AddressableUIPartsEnum addressableUIPartsEnum)
        {
            switch (addressableUIPartsEnum)
            {
                case AddressableUIPartsEnum.BattleSelectButton:
                    return AddressableConst.battleSelectButtonUI;

                case AddressableUIPartsEnum.GachaSelectButton:
                    return AddressableConst.gachaSelectButtonUI;

                default:
                    return AddressableConst.battleSelectButtonUI;
            }
        }
    }
}
