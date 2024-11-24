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

namespace My.ClickerGame
{
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
        private UpgradeComponentType upgradeComponentType = UpgradeComponentType.Money;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            AddListener();
            InitializeText();
        }

        private void AddListener()
        {
            _itemPresenter.upgradeComponents.CollectionChanged += (in NotifyCollectionChangedEventArgs<UpgradeComponent> args) =>
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Debug.Log($"HeaderTextView : Add : [{args.NewStartingIndex}] = {args.NewItem}");
                        ChangeText(args.NewItem);
                        break;
                    case NotifyCollectionChangedAction.Move:
                        Debug.Log(
                            $"HeaderTextView : Move : [{args.OldStartingIndex}] => [{args.NewStartingIndex}]");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Debug.Log($"HeaderTextView : Remove : [{args.OldStartingIndex}] = {args.OldItem}");
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        Debug.Log($"HeaderTextView : Replace : [{args.OldStartingIndex}] = ({args.OldItem} => {args.NewItem})");
                        ChangeText(args.NewItem);
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        Debug.Log("HeaderTextView : Reset");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };
        }

        private void InitializeText()
        {
            var upgradeComponent = _itemPresenter.GetUpgradeComponentValue(upgradeComponentType);
            ChangeText(upgradeComponent);
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
}
