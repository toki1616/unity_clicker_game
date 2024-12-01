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
                var upgradeanleItem = new UpgradeableItem(value);
                switch (value)
                {
                    case UpgradeableItemType.Shot:
                        upgradeanleItem.SetLevel(1);
                        upgradeanleItem.SetNextLevel(10);
                        upgradeanleItem.SetUpgradeComponentType(UpgradeComponentType.Money);
                        break;

                    case UpgradeableItemType.FighterJetCount:
                        upgradeanleItem.SetLevel(1);
                        upgradeanleItem.SetNextLevel(100);
                        upgradeanleItem.SetUpgradeComponentType(UpgradeComponentType.Money);
                        break;

                    case UpgradeableItemType.Support:
                        upgradeanleItem.SetLevel(1);
                        upgradeanleItem.SetNextLevel(1000);
                        upgradeanleItem.SetUpgradeComponentType(UpgradeComponentType.Money);
                        break;
                }

                _upgradeableItems.Add(upgradeanleItem);
            }
        }

        public UpgradeableItem GetUpgradeableItemValue(UpgradeableItemType upgradeableItemType)
        {
            var itemToUpgrade = _upgradeableItems.FirstOrDefault(item => item.UpgradeableItemType == upgradeableItemType);
            return itemToUpgrade;
        }

        public void LevelUpUpgradeableItem(UpgradeableItemType upgradeableItemType)
        {
            var upgradeableItem = _upgradeableItems.FirstOrDefault(item => item.UpgradeableItemType == upgradeableItemType); if (upgradeableItem != null)
            {
                var upgradeComponent = _upgradeComponents.FirstOrDefault(item => item.UpgradeComponentType == upgradeableItem.UpgradeComponentType);

                if (upgradeableItem.NextLevel <= upgradeComponent.Count)
                {
                    upgradeComponent.MinusCount(upgradeableItem.NextLevel);
                    upgradeableItem.LevelUp();

                    _upgradeComponents[_upgradeComponents.IndexOf(upgradeComponent)] = upgradeComponent;
                    _upgradeableItems[_upgradeableItems.IndexOf(upgradeableItem)] = upgradeableItem;
                }
            }
        }
    }
}
