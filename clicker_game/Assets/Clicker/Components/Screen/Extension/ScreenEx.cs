using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.ClickerGame.Const;

namespace My.ClickerGame.Ex
{
    public static class ScreenEx
    {
        public static string GetAddressableNameFromScreenType(this ScreenType screenType)
        {
            switch (screenType)
            {
                case ScreenType.Home:
                    return AddressableConst.homeUI;

                case ScreenType.BattleSelect:
                    return AddressableConst.battleSelectUI;

                case ScreenType.Battle:
                    return AddressableConst.battleUI;

                case ScreenType.GachaSelect:
                    return AddressableConst.gachaSelectUI;

                case ScreenType.Gacha:
                    return AddressableConst.gachaUI;

                case ScreenType.Other:
                    return AddressableConst.otherUI;

                case ScreenType.Setting:
                    return AddressableConst.settingUI;

                default:
                    return AddressableConst.otherUI;
            }
        }

        public static ScreenSize GetScreenSizeFromScreenType(this ScreenType screenType)
        {
            switch (screenType)
            {
                case ScreenType.Home:
                    return ScreenSize.SafeArea;

                case ScreenType.BattleSelect:
                    return ScreenSize.SafeArea;

                case ScreenType.Battle:
                    return ScreenSize.SafeArea;

                case ScreenType.GachaSelect:
                    return ScreenSize.SafeArea;

                case ScreenType.Gacha:
                    return ScreenSize.SafeArea;

                case ScreenType.Other:
                    return ScreenSize.SafeArea;

                case ScreenType.Setting:
                    return ScreenSize.SafeArea;

                default:
                    return ScreenSize.SafeArea;
            }
        }
    }
}
