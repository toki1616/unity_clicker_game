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
            InitializeUpgradeComponents();
            InitializeUpgradeableItems();
        }

        //UpgradeComponent
        public ObservableList<UpgradeComponent> _upgradeComponents = new ObservableList<UpgradeComponent>();

        private void InitializeUpgradeComponents()
        {
            foreach (UpgradeComponentEnum value in Enum.GetValues(typeof(UpgradeComponentEnum)))
            {
                _upgradeComponents.Add(new UpgradeComponent(value, 0));
            }
        }

        public void AddUpgradeComponent(UpgradeComponentEnum upgradeComponentType)
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
            foreach (UpgradeableItemEnum value in Enum.GetValues(typeof(UpgradeableItemEnum)))
            {
                _upgradeableItems.Add(new UpgradeableItem(value, 0));
            }
        }

        public void AddUpgradeableItem(UpgradeableItemEnum upgradeableItemType)
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
