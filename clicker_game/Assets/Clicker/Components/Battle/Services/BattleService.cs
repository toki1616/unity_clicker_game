using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.ClickerGame
{
    public class BattleService
    {
        private readonly EnemyModel _enemyModel;
        private readonly BattleModel _battleModel;

        public BattleService
            (
            EnemyModel enemyModel,
            BattleModel battleModel
            )
        {
            Debug.Log("BattleService : Inject");
            _enemyModel = enemyModel;
            _battleModel = battleModel;
        }

        public Enemy GetEnemyFromEnemyID(int enemyID)
        {
            return _enemyModel.GetEnemyFromEnemyID(enemyID);
        }
    }
}
