using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.ClickerGame
{
    public enum UpgradeableItemEnum
    {
        Shot,
        FighterJetCount,
        Support,
    }

    public class UpgradeableItem
    {
        private UpgradeableItemEnum upgradeableItemType;
        public UpgradeableItemEnum UpgradeableItemType
        {
            get
            {
                return upgradeableItemType;
            }
        }

        private int level;
        public int Level
        {
            get
            {
                return level;
            }
        }

        public UpgradeableItem(UpgradeableItemEnum upgradeableItemType, int level)
        {
            this.upgradeableItemType = upgradeableItemType;
            this.level = level;
        }

        public void LevelUp()
        {
            level++;
        }
    }
}
