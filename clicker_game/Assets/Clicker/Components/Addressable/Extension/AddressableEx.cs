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

        //UI
        public static string GetAddressableNameFromScreenType(this AddressableUIType addressableUIType)
        {
            switch (addressableUIType)
            {
                case AddressableUIType.Home:
                    return AddressableConst.homeUI;

                //Battle
                case AddressableUIType.BattleSelect:
                    return AddressableConst.battleSelectUI;

                case AddressableUIType.Battle:
                    return AddressableConst.battleUI;

                case AddressableUIType.BattleResult:
                    return AddressableConst.battleResultUI;

                //Gacha
                case AddressableUIType.GachaSelect:
                    return AddressableConst.gachaSelectUI;

                case AddressableUIType.Gacha:
                    return AddressableConst.gachaUI;

                case AddressableUIType.GachaResult:
                    return AddressableConst.gachaResultUI;

                case AddressableUIType.Other:
                    return AddressableConst.otherUI;

                case AddressableUIType.Setting:
                    return AddressableConst.settingUI;

                default:
                    return AddressableConst.otherUI;
            }
        }

        public static ScreenSize GetScreenSizeFromScreenType(this AddressableUIType addressableUIType)
        {
            switch (addressableUIType)
            {
                case AddressableUIType.Home:
                    return ScreenSize.SafeArea;

                case AddressableUIType.BattleSelect:
                    return ScreenSize.SafeArea;

                case AddressableUIType.Battle:
                    return ScreenSize.Full;

                case AddressableUIType.BattleResult:
                    return ScreenSize.Full;

                case AddressableUIType.GachaSelect:
                    return ScreenSize.SafeArea;

                case AddressableUIType.Gacha:
                    return ScreenSize.Full;

                case AddressableUIType.Other:
                    return ScreenSize.SafeArea;

                case AddressableUIType.Setting:
                    return ScreenSize.SafeArea;

                default:
                    return ScreenSize.SafeArea;
            }
        }

        //UIParts
        public static string GetAddressableName(this AddressableUIPartsEnum addressableUIPartsEnum)
        {
            switch (addressableUIPartsEnum)
            {
                case AddressableUIPartsEnum.BattleSelectButton:
                    return AddressableConst.battleSelectButtonUI;

                case AddressableUIPartsEnum.GachaSelectButton:
                    return AddressableConst.gachaSelectButtonUI;
                    
                case AddressableUIPartsEnum.UpgradeableItemUI:
                    return AddressableConst.upgradeableItemUI;

                default:
                    return AddressableConst.battleSelectButtonUI;
            }
        }
    }
}
