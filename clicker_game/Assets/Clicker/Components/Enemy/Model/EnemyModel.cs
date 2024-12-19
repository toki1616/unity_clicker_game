using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using ObservableCollections;


namespace My.ClickerGame
{
    public class EnemyModel
    {
        public EnemyModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeEnemyList();
        }

        //Enemy
        public ObservableList<Enemy> enemyList = new ObservableList<Enemy>();

        private void InitializeEnemyList()
        {
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            EnemyDropItem[] enemyDropItems = new EnemyDropItem[]
                            {
                                new EnemyDropItem(dropItemType: UpgradeComponentType.Money, dropCount: 100, dropRate: 100),
                            };
                            Enemy enemy = new Enemy(id: i, name: "test1", hitPoint: 100, enemyDropItems: enemyDropItems);

                            enemyList.Add(enemy);
                            break;
                        }

                    case 1:
                        {
                            EnemyDropItem[] enemyDropItems = new EnemyDropItem[]
                            {
                                new EnemyDropItem(dropItemType: UpgradeComponentType.Money, dropCount: 100, dropRate: 90),
                                new EnemyDropItem(dropItemType: UpgradeComponentType.Money, dropCount: 1000, dropRate: 10),
                            };
                            Enemy enemy = new Enemy(id: i, name: "test2", hitPoint: 500, enemyDropItems: enemyDropItems);

                            enemyList.Add(enemy);
                            break;
                        }

                    case 2:
                        {
                            EnemyDropItem[] enemyDropItems = new EnemyDropItem[]
                            {
                                new EnemyDropItem(dropItemType: UpgradeComponentType.Money, dropCount: 1000, dropRate: 90),
                                new EnemyDropItem(dropItemType: UpgradeComponentType.Money, dropCount: 10000, dropRate: 10),
                            };
                            Enemy enemy = new Enemy(id: i, name: "test3", hitPoint: 1000, enemyDropItems: enemyDropItems);

                            enemyList.Add(enemy);
                            break;
                        }

                    case 3:
                        {
                            EnemyDropItem[] enemyDropItems = new EnemyDropItem[]
                            {
                                new EnemyDropItem(dropItemType: UpgradeComponentType.Money, dropCount: 10000, dropRate: 90),
                                new EnemyDropItem(dropItemType: UpgradeComponentType.Money, dropCount: 100000, dropRate: 10),
                            };
                            Enemy enemy = new Enemy(id: i, name: "test4", hitPoint: 5000, enemyDropItems: enemyDropItems);

                            enemyList.Add(enemy);
                            break;
                        }

                    default:
                        {
                            EnemyDropItem[] enemyDropItems = new EnemyDropItem[]
                            {
                                new EnemyDropItem(dropItemType: UpgradeComponentType.Money, dropCount: 100000, dropRate: 90),
                                new EnemyDropItem(dropItemType: UpgradeComponentType.Money, dropCount: 1000000, dropRate: 10),
                            };
                            Enemy enemy = new Enemy(id: i, name: "test5", hitPoint: 10000, enemyDropItems: enemyDropItems);

                            enemyList.Add(enemy);
                            break;
                        }
                }
            }
        }

        public List<Enemy> GetEnemyList()
        {
            return enemyList.ToList();
        }
    }
}
