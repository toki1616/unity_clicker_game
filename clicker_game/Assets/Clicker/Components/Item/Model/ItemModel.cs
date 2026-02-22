using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using ObservableCollections;
using Cysharp.Threading.Tasks;

using My.ClickerGame.Const;
using My.Save.Json;

namespace My.ClickerGame
{
    public class ItemModel
    {
        public ItemModel()
        {
            Initialize();
            ExecuteEverySecond().Forget();
        }

        private void Initialize()
        {
            InitializeUpgradeComponents();
            InitializeUpgradeableItems();
        }

        private async UniTaskVoid ExecuteEverySecond()
        {
            while (true)
            {
                // 1秒待つ
                await UniTask.Delay(1000);
                AddSecondUpgradeComponents();
            }
        }

        //UpgradeComponent
        public ObservableList<UpgradeComponent> _upgradeComponents = new ObservableList<UpgradeComponent>();

        private void InitializeUpgradeComponents()
        {
            _upgradeComponents.Clear();

            // load
            var loaded = JsonSaveUtils.Load<List<UpgradeComponent>>(SaveKey.ItemData.ToString());

            if (loaded != null && loaded.Count > 0)
            {
                foreach (var item in loaded)
                {
                    _upgradeComponents.Add(item);
                }

                return;
            }

            // initialize
            _upgradeComponents.Clear();

            foreach (UpgradeComponentType value in Enum.GetValues(typeof(UpgradeComponentType)))
            {
                _upgradeComponents.Add(new UpgradeComponent(value, 0)); // Add 通知
            }
        }

        public UpgradeComponent GetUpgradeComponent(UpgradeComponentType upgradeComponentType)
        {
            var itemToUpdate = _upgradeComponents.FirstOrDefault(item => item.UpgradeComponentType == upgradeComponentType);
            return itemToUpdate;
        }

        public void AddUpgradeComponent(UpgradeComponentType upgradeComponentType, int addCount = 1)
        {
            var itemToUpdate = _upgradeComponents.FirstOrDefault(item => item.UpgradeComponentType == upgradeComponentType); if (itemToUpdate != null)
            {
                itemToUpdate.AddCount(addCount);
                var index = _upgradeComponents.IndexOf(itemToUpdate);

                _upgradeComponents[index] = itemToUpdate;
            }

            SaveUpgradeComponents();
        }

        private void AddSecondUpgradeComponents()
        {
            //Debug.Log("AddSecondUpgradeComponents");
            UpgradeableItem supportItem = GetUpgradeableItemValue(UpgradeableItemType.Support);

            int addCount = ItemConst.baseSecoundAddMoney * supportItem.Level;

            if (addCount <= 0)
            {
                return;
            }

            AddUpgradeComponent(UpgradeComponentType.Money, addCount);
        }

        //UpgradeableItem
        public ObservableList<UpgradeableItem> _upgradeableItems = new ObservableList<UpgradeableItem>();

        private void InitializeUpgradeableItems()
        {
            _upgradeableItems.Clear();

            //load
            var loaded = JsonSaveUtils.Load<List<UpgradeableItem>>(SaveKey.LevelData.ToString());

            if (loaded != null && loaded.Count > 0)
            {
                _upgradeableItems.Clear();

                foreach (var item in loaded)
                {
                    _upgradeableItems.Add(item);
                }

                return;
            }

            //initialize
            foreach (UpgradeableItemType value in Enum.GetValues(typeof(UpgradeableItemType)))
            {
                var upgradeanleItem = new UpgradeableItem(value);

                switch (value)
                {
                    case UpgradeableItemType.Shot:
                        upgradeanleItem.SetLevel(0);
                        upgradeanleItem.SetNextLevel(10);
                        upgradeanleItem.SetUpgradeComponentType(UpgradeComponentType.Money);
                        break;

                    case UpgradeableItemType.FighterJetCount:
                        upgradeanleItem.SetLevel(0);
                        upgradeanleItem.SetNextLevel(100);
                        upgradeanleItem.SetUpgradeComponentType(UpgradeComponentType.Money);
                        break;

                    case UpgradeableItemType.Support:
                        upgradeanleItem.SetLevel(0);
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

                    SaveUpgradeableItems();
                }
            }
        }

        public void OnTapHome()
        {
            UpgradeableItem shotItem = GetUpgradeableItemValue(UpgradeableItemType.Shot);
            UpgradeableItem JetItem = GetUpgradeableItemValue(UpgradeableItemType.FighterJetCount);

            var addCount = (ItemConst.baseTapAddMoneyShot * shotItem.Level) + (ItemConst.baseTapAddMoneyJet * JetItem.Level);
            AddUpgradeComponent(UpgradeComponentType.Money, addCount);
        }

        private void SaveUpgradeComponents()
        {
            JsonSaveUtils.Save(SaveKey.ItemData.ToString(), _upgradeComponents.ToList());
        }

        private void SaveUpgradeableItems()
        {
            SaveUpgradeComponents();
            JsonSaveUtils.Save(SaveKey.LevelData.ToString(), _upgradeableItems.ToList());
        }
    }
}
