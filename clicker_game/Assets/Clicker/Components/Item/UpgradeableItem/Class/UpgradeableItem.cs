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
        public UpgradeComponentType UpgradeComponentType { get; private set; }
        public int Level { get; private set; }

        public int NextLevel { 
            get {
                switch (UpgradeableItemType)
                {
                    case UpgradeableItemType.Shot:
                        return nextLevel * Level;

                    default:
                        return nextLevel * (1 + Level);
                } 
            }
        }
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

        public void SetUpgradeComponentType(UpgradeComponentType upgradeComponentType)
        {
            UpgradeComponentType = upgradeComponentType;
        }

        public void LevelUp()
        {
            Level++;
        }
    }
}
