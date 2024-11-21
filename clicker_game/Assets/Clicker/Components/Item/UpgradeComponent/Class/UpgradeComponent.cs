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
        private UpgradeComponentEnum upgradeComponentType;
        public UpgradeComponentEnum UpgradeComponentType
        {
            get
            {
                return upgradeComponentType;
            }
        }

        private int count;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public UpgradeComponent(UpgradeComponentEnum upgradeComponentType, int count)
        {
            this.upgradeComponentType = upgradeComponentType;
            this.count = count;
        }

        public void AddCount(int addCount)
        {
            count += addCount;
        }
    }
}
