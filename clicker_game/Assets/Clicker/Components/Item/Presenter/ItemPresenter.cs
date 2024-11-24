using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using ObservableCollections;

namespace My.ClickerGame
{
    public class ItemPresenter
    {
        private readonly ItemModel _itemModel;

        public ItemPresenter
            (
            ItemModel itemModel
            )
        {
            Debug.Log("ItemPresenter : Inject");
            _itemModel = itemModel;
        }

        /// <summary>
        /// UpgradeComponent
        /// </summary>
        public IObservableCollection<UpgradeComponent> upgradeComponents =>
            _itemModel._upgradeComponents;

        public void OnTapHome()
        {
            _itemModel.AddUpgradeComponent(UpgradeComponentType.Money);
        }

        public UpgradeComponent GetUpgradeComponentValue(UpgradeComponentType upgradeComponentType)
        {
            return _itemModel.GetUpgradeComponent(upgradeComponentType);
        }

        //UpgradeableItem
        public IObservableCollection<UpgradeableItem> upgradeableItems =>
           _itemModel._upgradeableItems;

        public UpgradeableItem GetUpgradeableItemValue(UpgradeableItemType upgradeableItemType)
        {
            return _itemModel.GetUpgradeableItemValue(upgradeableItemType);
        }
    }
}
