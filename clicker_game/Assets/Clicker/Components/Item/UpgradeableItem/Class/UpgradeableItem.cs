using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.ClickerGame
{
    public enum UpgradeableItemType
    {
        Shot,
        FighterJetCount,
        Support,
    }

    public class UpgradeableItem
    {
        public UpgradeableItemType UpgradeableItemType { get; private set; }
        public int Level { get; private set; }

        public UpgradeableItem(UpgradeableItemType upgradeableItemType, int level)
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
