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
                            EnemyDropItemRate[] enemyDropItems = new EnemyDropItemRate[]
                            {
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 100, dropRate: 100),
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 1000, dropRate: 50),
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 1000, dropRate: 10),
                            };
                            Enemy enemy = new Enemy(id: 0, name: "test1", hitPoint: 1, enemyDropItems: enemyDropItems);

                            enemyList.Add(enemy);
                            break;
                        }

                    case 1:
                        {
                            EnemyDropItemRate[] enemyDropItems = new EnemyDropItemRate[]
                            {
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 100, dropRate: 90),
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 1000, dropRate: 10),
                            };
                            Enemy enemy = new Enemy(id: 1, name: "test2", hitPoint: 500, enemyDropItems: enemyDropItems);

                            enemyList.Add(enemy);
                            break;
                        }

                    case 2:
                        {
                            EnemyDropItemRate[] enemyDropItems = new EnemyDropItemRate[]
                            {
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 1000, dropRate: 90),
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 10000, dropRate: 10),
                            };
                            Enemy enemy = new Enemy(id: 2, name: "test3", hitPoint: 1000, enemyDropItems: enemyDropItems);

                            enemyList.Add(enemy);
                            break;
                        }

                    case 3:
                        {
                            EnemyDropItemRate[] enemyDropItems = new EnemyDropItemRate[]
                            {
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 10000, dropRate: 90),
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 100000, dropRate: 10),
                            };
                            Enemy enemy = new Enemy(id: 3, name: "test4", hitPoint: 5000, enemyDropItems: enemyDropItems);

                            enemyList.Add(enemy);
                            break;
                        }

                    default:
                        {
                            EnemyDropItemRate[] enemyDropItems = new EnemyDropItemRate[]
                            {
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 100000, dropRate: 90),
                                new EnemyDropItemRate(dropItemType: UpgradeComponentType.Money, dropCount: 1000000, dropRate: 10),
                            };
                            Enemy enemy = new Enemy(id: 4, name: "test5", hitPoint: 10000, enemyDropItems: enemyDropItems);

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

        public Enemy GetEnemyFromEnemyID(int enemyID)
        {
            if (enemyList == null)
            {
                Debug.LogError("enemyList is null");
                return null;
            }

            var selectedEnemy = enemyList.FirstOrDefault(enemy => enemy.ID == enemyID);

            if (selectedEnemy == null)
            {
                Debug.LogError($"No enemy found with ID: {enemyID}");
            }

            return selectedEnemy;
        }
    }
}
