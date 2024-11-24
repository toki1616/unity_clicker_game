using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Zenject;
using R3;
using R3.Triggers;
using ObservableCollections;

namespace My.ClickerGame
{
    public class UpgradeableItemCreateView : MonoBehaviour
    {
        private ItemPresenter _itemPresenter;

        [Inject]
        public void Construct
            (
                ItemPresenter itemPresenter
            )
        {
            Debug.Log("UpgradeableItemCreateView : Inject");
            _itemPresenter = itemPresenter;
        }

        [SerializeField]
        private GameObject _spawnPrefab;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateUpgradeableItemView();
        }

        private void CreateUpgradeableItemView()
        {
            foreach (UpgradeableItemType value in Enum.GetValues(typeof(UpgradeableItemType)))
            {
                GameObject spawnObject = Instantiate(_spawnPrefab, this.transform);
                spawnObject.GetComponent<UpgradeableItemView>().SetUpgradeableItemType(value);
            }
        }
    }
}
