using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Zenject;
using R3;
using R3.Triggers;
using ObservableCollections;
using TMPro;

public class HeaderTextView : MonoBehaviour
{
    private ItemPresenter _itemPresenter;

    [Inject]
    public void Construct
        (
            ItemPresenter itemPresenter
        )
    {
        _itemPresenter = itemPresenter;
    }
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private UpgradeComponentEnum upgradeComponentType = UpgradeComponentEnum.Money;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();

        _itemPresenter.upgradeComponents.CollectionChanged += (in NotifyCollectionChangedEventArgs<UpgradeComponent> args) =>
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Debug.Log($"Add:[{args.NewStartingIndex}] = {args.NewItem}");
                    ChangeText(args.NewItem);
                    break;
                case NotifyCollectionChangedAction.Move:
                    Debug.Log(
                        $"Move:[{args.OldStartingIndex}] => [{args.NewStartingIndex}]");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Debug.Log($"Remove:[{args.OldStartingIndex}] = {args.OldItem}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Debug.Log($"Replace:[{args.OldStartingIndex}] = ({args.OldItem} => {args.NewItem})");
                    ChangeText(args.NewItem);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Debug.Log("Reset");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        };
    }

    private void Initialize()
    {
        text.text = $"money : 0";
    }

    private void ChangeText(UpgradeComponent upgradeComponent)
    {
        if (upgradeComponent.UpgradeComponentType != upgradeComponentType)
        {
            return;
        }

        text.text = $"money : {upgradeComponent.Count}";
    }
}
