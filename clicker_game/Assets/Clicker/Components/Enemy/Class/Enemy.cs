using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.ClickerGame.Utils;

namespace My.ClickerGame
{
    public class Enemy
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int HitPoint { get; private set; }
        public EnemyDropItemRate[] DropItems { get; private set; }
        public bool isDisplay { get; private set; }

        public Enemy(int id, string name, int hitPoint, EnemyDropItemRate[] enemyDropItems)
        {
            ID = id;
            Name = name;
            HitPoint = hitPoint;
            DropItems = enemyDropItems;
        }

        public void HitPointMinus(int attackValue)
        {
            HitPoint -= attackValue;
            HitPoint = Mathf.Max(HitPoint, 0);
        }

        public EnemyDropItem[] DropItem()
        {
            List<EnemyDropItem> droppedItems = new List<EnemyDropItem>();
            System.Random random = new System.Random();

            foreach (var item in DropItems)
            {
                int roll = random.Next(0, 100); // 1から100までのランダムな整数を生成
                if (roll <= item.DropRate)
                {
                    droppedItems.Add(item.EnemyDropItem);
                }
            }

            Debug.Log($"dropItems : {JsonUtils.GetJsonFromArray(DropItems)}");
            Debug.Log($"droppedItems : {JsonUtils.GetJsonFromArray(droppedItems.ToArray())}");
            return droppedItems.ToArray();
        }
    }

    [Serializable]
    public class EnemyDropItemRate
    {
        [SerializeField]
        private EnemyDropItem enemyDropItem;
        public EnemyDropItem EnemyDropItem
        {
            get
            {
                return enemyDropItem;
            }
        }

        [SerializeField]
        private int dropRate;
        public int DropRate
        {
            get
            {
                return dropRate;
            }
        }

        public EnemyDropItemRate(EnemyDropItem enemyDropItem, int dropRate)
        {
            this.enemyDropItem = enemyDropItem;
            this.dropRate = dropRate;
        }

        public EnemyDropItemRate(UpgradeComponentType dropItemType, int dropCount, int dropRate)
        {
            enemyDropItem = new EnemyDropItem(dropItemType, dropCount);
            this.dropRate = dropRate;
        }
    }

    [Serializable]
    public class EnemyDropItem
    {
        [SerializeField]
        private UpgradeComponentType dropItemType;
        public UpgradeComponentType DropItemType
        {
            get
            {
                return dropItemType;
            }
        }

        [SerializeField]
        private int dropCount;
        public int DropCount
        {
            get
            {
                return dropCount;
            }
        }

        public EnemyDropItem(UpgradeComponentType dropItemType, int dropCount)
        {
            this.dropItemType = dropItemType;
            this.dropCount = dropCount;
        }
    }
}
