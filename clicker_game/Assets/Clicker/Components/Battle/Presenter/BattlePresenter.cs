using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

namespace My.ClickerGame
{
    public class BattlePresenter
    {
        private readonly BattleService _battleService;
        private readonly BattleModel _battleModel;

        public BattlePresenter
            (
            BattleModel battleModel,
            BattleService battleService
            )
        {
            Debug.Log("BattlePresenter : Inject");
            _battleModel = battleModel;
            _battleService = battleService;
        }

        //Battle
        public Observable<float> RemainingTimeObservable =>
            _battleModel.RemainingTime
            .Publish()
            .RefCount();

        //Enemy
        public Observable<Enemy> SelectEnemyObservable =>
            _battleModel.SelectEnemy
            .Do(_ => {
                Debug.Log($"SelectEnemyObservable : EnemyID : {_.ID} : {_.HitPoint}");
            })
            .Publish()
            .RefCount();

        public void SelectEnemyForceNotify()
        {
            _battleModel.SelectEnemyForceNotify();
        }

        public void BattleSelect(int enemyID)
        {
            Enemy enemy = _battleService.GetEnemyFromEnemyID(enemyID);
            _battleModel.BattleSelect(enemy);
        }

        public void OnTapBattleDamage()
        {
            _battleModel.OnTapBattleDamage();
        }
    }
}
