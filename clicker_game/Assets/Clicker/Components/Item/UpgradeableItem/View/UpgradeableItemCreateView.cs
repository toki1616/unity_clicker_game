using System;
using UnityEngine;

namespace My.ClickerGame
{
    public class UpgradeableItemCreateView : MonoBehaviour
    {
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
