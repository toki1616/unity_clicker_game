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

        public int NextLevel { get { return nextLevel * Level; } }
        private int nextLevel;

        public UpgradeableItem(UpgradeableItemType upgradeableItemType)
        {
            UpgradeableItemType = upgradeableItemType;
        }

        public void SetLevel(int value)
        {
            Level = value;
        }

        public void SetNextLevel(int value)
        {
            nextLevel = value;
        }

        public void LevelUp()
        {
            Level++;
        }
    }
}
