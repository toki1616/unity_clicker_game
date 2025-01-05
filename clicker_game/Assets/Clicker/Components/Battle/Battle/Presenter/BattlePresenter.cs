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

            AddListener();
        }

        private void AddListener()
        {
            _battleModel.MoveScreenSuccessAsObservable.Subscribe(_ => MoveScreenSuccess());
            _battleModel.MoveScreenBattleSelectAsObservable.Subscribe(_ => MoveScreenBattleSelect());
        }

        //Battle
        public Observable<float> RemainingTimeObservable =>
            _battleModel.RemainingTime
            .Publish()
            .RefCount();

        public Observable<bool> IsGameEndSuccessObservable =>
            _battleModel.IsGameEndSuccessObservable
            //.Do(_ => {
            //    Debug.Log($"SelectEnemyObservable : EnemyID : {_.ID} : {_.HitPoint}");
            //})
            .Publish()
            .RefCount();

        public void StartGame()
        {
            _battleModel.StartGame();
        }

        //Enemy
        public Observable<Enemy> SelectEnemyObservable =>
            _battleModel.SelectEnemy
            //.Do(_ => {
            //    Debug.Log($"SelectEnemyObservable : EnemyID : {_.ID} : {_.HitPoint}");
            //})
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

        public void OnTapBattlePanel()
        {
            _battleModel.OnTapBattlePanel();
        }

        public void OnTapBattleResultPanel()
        {
            _battleModel.OnTapBattleResultPanel();
        }

        public void MoveScreenSuccess()
        {
            Debug.Log("MoveScreenSuccess");
            _battleService.MoveScreenSuccess();
        }

        public void MoveScreenBattleSelect()
        {
            Debug.Log("MoveScreenBattleSelect");
            _battleService.MoveScreenBattleSelect();
        }
    }
}
