using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.ClickerGame
{
    public class Enemy
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int HitPoint { get; private set; }
        public EnemyDropItem[] DropItems { get; private set; }
        public bool isDisplay { get; private set; }

        public Enemy(int id, string name, int hitPoint, EnemyDropItem[] enemyDropItems)
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
    }
    
    public class EnemyDropItem
    {
        public UpgradeComponentType DropItemType { get; private set; }
        public int DropCount { get; private set; }
        public int DropRate { get; private set; }

        public EnemyDropItem(UpgradeComponentType dropItemType, int dropCount, int dropRate)
        {
            DropItemType = dropItemType;
            DropCount = dropCount;
            DropRate = dropRate;
        }
    }
}
