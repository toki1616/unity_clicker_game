using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using ObservableCollections;

namespace My.ClickerGame
{
    public class EnemyPresenter
    {
        private readonly EnemyModel _enemyModel;

        public EnemyPresenter
            (
            EnemyModel enemyModel
            )
        {
            //Debug.Log("EnemyPresenter : Inject");
            _enemyModel = enemyModel;
        }

        //Enemy
        public IObservableCollection<Enemy> enemyList =>
               _enemyModel.enemyList;

        public List<Enemy> GetEnemyList()
        {
            return _enemyModel.GetEnemyList();
        }
    }
}
