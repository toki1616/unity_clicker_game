using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.ClickerGame.MyEnum
{
    public enum AddressableGroupEnum
    {
        UI,
        UIParts,
    }

    public enum AddressableUIType
    {
        //Home
        Home,

        //Battle
        BattleSelect,
        Battle,
        BattleResult,

        //Gacha
        GachaSelect,
        Gacha,
        GachaResult,

        //Other
        Other,
        Setting,
    }

    public enum AddressableUIPartsEnum
    {
        BattleSelectButton,
        GachaSelectButton,
        UpgradeableItemUI,
    }
}
