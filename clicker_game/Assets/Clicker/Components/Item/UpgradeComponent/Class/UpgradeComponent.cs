using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.ClickerGame
{
    public enum UpgradeComponentEnum
    {
        Money,
        Component,
    }

    public class UpgradeComponent
    {
        public UpgradeComponentEnum UpgradeComponentType { get; private set; }
        public int Count { get; private set; }

        public UpgradeComponent(UpgradeComponentEnum upgradeComponentType, int count)
        {
            this.UpgradeComponentType = upgradeComponentType;
            this.Count = count;
        }

        public void AddCount(int addCount)
        {
            Count += addCount;
        }
    }
}
