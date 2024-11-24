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
        public UpgradeableItemEnum UpgradeableItemType { get; private set; }
        public int Level { get; private set; }

        public UpgradeableItem(UpgradeableItemEnum upgradeableItemType, int level)
        {
            UpgradeableItemType = upgradeableItemType;
            Level = level;
        }

        public void LevelUp()
        {
            Level++;
        }
    }
}
