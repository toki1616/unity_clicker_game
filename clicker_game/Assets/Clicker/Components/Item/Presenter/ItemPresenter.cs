using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using ObservableCollections;

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
        _itemModel.AddUpgradeComponent(UpgradeComponentEnum.Money);
    }
}
