using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using R3;
using R3.Triggers;
using ObservableCollections;
using TMPro;

namespace My.ClickerGame
{
    public class UpgradeableItemView : MonoBehaviour
    {
        private ItemPresenter _itemPresenter;

        [Inject]
        public void Construct
            (
                ItemPresenter itemPresenter
            )
        {
            Debug.Log("UpgradeableItemView : Inject");
            _itemPresenter = itemPresenter;
        }

        [SerializeField]
        private TextMeshProUGUI _typeTMPro;

        [SerializeField]
        private TextMeshProUGUI _levelTMPro;

        [SerializeField]
        private TextMeshProUGUI _nextLevelTMPro;

        [SerializeField]
        private Button _levelUpButton;


        private UpgradeableItemType _upgradeableItemType = UpgradeableItemType.Shot;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        public void SetUpgradeableItemType(UpgradeableItemType upgradeableItemType)
        {
            _upgradeableItemType = upgradeableItemType;
            _typeTMPro.text = $"{upgradeableItemType}";
        }

        private void Initialize()
        {
            AddListener();
            SetUpgradeableLebel();
        }

        private void AddListener()
        {
            _itemPresenter.upgradeableItems.CollectionChanged += (in NotifyCollectionChangedEventArgs<UpgradeableItem> args) =>
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Debug.Log($"HeaderTextView : Add : [{args.NewStartingIndex}] = {args.NewItem}");
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
                        ChangeLevelText(args.NewItem);
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        Debug.Log("HeaderTextView : Reset");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };

            _levelUpButton
                .OnClickAsObservable()
                .Subscribe(_ => OnClickLevelUpButton());
        }

        private void SetUpgradeableLebel()
        {
            var upgradeComponent = _itemPresenter.GetUpgradeableItemValue(_upgradeableItemType);
            ChangeLevelText(upgradeComponent);
        }

        private void ChangeLevelText(UpgradeableItem upgradeableItem)
        {
            if (upgradeableItem.UpgradeableItemType != _upgradeableItemType)
            {
                return;
            }

            _levelTMPro.text = $"Level : {upgradeableItem.Level}";
        }

        private void OnClickLevelUpButton()
        {
            _itemPresenter.LevelUpUpgradeableItem(_upgradeableItemType);
        }
    }
}
