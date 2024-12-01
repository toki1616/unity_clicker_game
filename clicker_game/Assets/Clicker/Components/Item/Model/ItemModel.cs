using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using ObservableCollections;

namespace My.ClickerGame
{
    public class ItemModel
    {
        public ItemModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeUpgradeComponents();
            InitializeUpgradeableItems();
        }

        //UpgradeComponent
        public ObservableList<UpgradeComponent> _upgradeComponents = new ObservableList<UpgradeComponent>();

        private void InitializeUpgradeComponents()
        {
            foreach (UpgradeComponentType value in Enum.GetValues(typeof(UpgradeComponentType)))
            {
                _upgradeComponents.Add(new UpgradeComponent(value, 0));
            }
        }

        public UpgradeComponent GetUpgradeComponent(UpgradeComponentType upgradeComponentType)
        {
            var itemToUpdate = _upgradeComponents.FirstOrDefault(item => item.UpgradeComponentType == upgradeComponentType);
            return itemToUpdate;
        }

        public void AddUpgradeComponent(UpgradeComponentType upgradeComponentType)
        {
            var itemToUpdate = _upgradeComponents.FirstOrDefault(item => item.UpgradeComponentType == upgradeComponentType); if (itemToUpdate != null)
            {
                itemToUpdate.AddCount(1);
                var index = _upgradeComponents.IndexOf(itemToUpdate);

                _upgradeComponents[index] = itemToUpdate;
            }
        }

        //UpgradeableItem
        public ObservableList<UpgradeableItem> _upgradeableItems = new ObservableList<UpgradeableItem>();

        private void InitializeUpgradeableItems()
        {
            foreach (UpgradeableItemType value in Enum.GetValues(typeof(UpgradeableItemType)))
            {
                _upgradeableItems.Add(new UpgradeableItem(value, 1));
            }
        }

        public UpgradeableItem GetUpgradeableItemValue(UpgradeableItemType upgradeableItemType)
        {
            var itemToUpgrade = _upgradeableItems.FirstOrDefault(item => item.UpgradeableItemType == upgradeableItemType);
            return itemToUpgrade;
        }

        public void LevelUpUpgradeableItem(UpgradeableItemType upgradeableItemType)
        {
            var itemToUpgrade = _upgradeableItems.FirstOrDefault(item => item.UpgradeableItemType == upgradeableItemType); if (itemToUpgrade != null)
            {
                itemToUpgrade.LevelUp();
                var index = _upgradeableItems.IndexOf(itemToUpgrade);

                _upgradeableItems[index] = itemToUpgrade;
            }
        }
    }
}
