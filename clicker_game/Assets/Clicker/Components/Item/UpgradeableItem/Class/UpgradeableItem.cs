using System;
using UnityEngine;

namespace My.ClickerGame
{
    public enum UpgradeableItemType
    {
        Shot,
        FighterJetCount,
        Support,
    }

    [Serializable]
    public class UpgradeableItem
    {
        [SerializeField]
        private UpgradeableItemType upgradeableItemType;

        [SerializeField]
        private UpgradeComponentType upgradeComponentType;

        [SerializeField]
        private int level;

        [SerializeField]
        private int nextLevelBase;

        public UpgradeableItemType UpgradeableItemType => upgradeableItemType;
        public UpgradeComponentType UpgradeComponentType => upgradeComponentType;
        public int Level => level;

        public int NextLevel
        {
            get
            {
                switch (upgradeableItemType)
                {
                    case UpgradeableItemType.Shot:
                        return nextLevelBase * level;

                    default:
                        return nextLevelBase * (1 + level);
                }
            }
        }

        public UpgradeableItem(UpgradeableItemType type)
        {
            upgradeableItemType = type;
        }

        public void SetLevel(int value)
        {
            level = value;
        }

        public void SetNextLevel(int value)
        {
            nextLevelBase = value;
        }

        public void SetUpgradeComponentType(UpgradeComponentType type)
        {
            upgradeComponentType = type;
        }

        public void LevelUp()
        {
            level++;
        }
    }
}
