using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class BattleService
    {
        private readonly EnemyModel _enemyModel;
        private readonly BattleModel _battleModel;
        private readonly ScreenModel _screenModel;

        public BattleService
            (
            EnemyModel enemyModel,
            BattleModel battleModel,
            ScreenModel screenModel
            )
        {
            Debug.Log("BattleService : Inject");
            _enemyModel = enemyModel;
            _battleModel = battleModel;
            _screenModel = screenModel;
        }

        public Enemy GetEnemyFromEnemyID(int enemyID)
        {
            return _enemyModel.GetEnemyFromEnemyID(enemyID);
        }

        public void MoveScreenSuccess()
        {
            _screenModel.MoveScreen(AddressableUIType.BattleResult);
        }

        public void MoveScreenBattleSelect()
        {
            _screenModel.MoveScreen(AddressableUIType.BattleSelect);
        }
    }
}
