using UnityEngine;
using TMPro;

namespace My.ClickerGame
{
    public class DropItemView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI itemName;

        [SerializeField]
        private TextMeshProUGUI itemCount;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetDropItem(EnemyDropItem dropItem)
        {
            itemName.text = $"{dropItem.DropItemType}";
            itemCount.text = $"{dropItem.DropCount}";
        }
    }
}
