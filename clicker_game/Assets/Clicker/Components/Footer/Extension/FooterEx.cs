using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.ClickerGame.Ex
{
    public static class FooterEx
    {
        public static string GetFooterMenuName(this FooterMenuType footerMenuType)
        {
            switch (footerMenuType)
            {
                case FooterMenuType.Home:
                    return "ホーム";
                case FooterMenuType.BattleSelect:
                    return "バトル";
                case FooterMenuType.GachaSelect:
                    return "ガチャ";
                case FooterMenuType.Other:
                    return "その他";
                default:
                    return "その他";
            }
        }
    }
}
