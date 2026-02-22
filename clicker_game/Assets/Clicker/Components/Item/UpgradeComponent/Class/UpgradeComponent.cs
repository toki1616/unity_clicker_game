using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.ClickerGame
{
    public enum UpgradeComponentType
    {
        Money,
        Component,
    }

    [Serializable]
    public class UpgradeComponent
    {
        public UpgradeComponentType UpgradeComponentType;
        public int Count;

        public UpgradeComponent(UpgradeComponentType upgradeComponentType, int count)
        {
            this.UpgradeComponentType = upgradeComponentType;
            this.Count = count;
        }

        public void AddCount(int addCount)
        {
            Count += addCount;
        }

        public void MinusCount(int minusCount)
        {
            Count -= minusCount;
        }
    }
}
