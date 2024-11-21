using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using ObservableCollections;

public class ItemModel
{
    //UpgradeComponent
    public ObservableList<UpgradeComponent> _upgradeComponents = new ObservableList<UpgradeComponent>();

    public ItemModel()
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
}
