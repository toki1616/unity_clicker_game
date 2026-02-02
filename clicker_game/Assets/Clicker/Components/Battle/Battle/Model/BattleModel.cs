using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class BattleModel
    {
        private const float baseTimeLimit = 30;

        public ReadOnlyReactiveProperty<float> RemainingTime => _remainingTime;
        private ReactiveProperty<float> _remainingTime = new ReactiveProperty<float>(baseTimeLimit);

        private BattlePhase _battlePhase = BattlePhase.Start;

        public Observable<bool> IsGameEndSuccessObservable => _isGameEndSuccessSubject;
        private Subject<bool> _isGameEndSuccessSubject = new Subject<bool>();
        private bool _isGameEndSuccess = false;

        private void InitializeGame()
        {
            _battlePhase = BattlePhase.Start;
            _remainingTime.Value = baseTimeLimit;
        }

        public void StartGame()
        {
            _battlePhase = BattlePhase.Battle;
            _remainingTime.Value = baseTimeLimit;

            StartCountdown();
        }

        private void StartCountdown()
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .TakeWhile(_ => _battlePhase == BattlePhase.Battle)
                .Subscribe(_ =>
                {
                    _remainingTime.Value--;
                    
                    if (_remainingTime.Value <= 0)
                    {
                        EndGame();
                    }
                });
        }

        private void EndGame()
        {
            _battlePhase = BattlePhase.End;

            if (_selectEnemy.Value.HitPoint <= 0)
            {
                Success();
                return;
            }

            Failure();
        }

        private void Success()
        {
            _isGameEndSuccessSubject.OnNext(true);
            _isGameEndSuccess = true;
        }

        private void Failure()
        {
            _isGameEndSuccessSubject.OnNext(false);
            _isGameEndSuccess = false;
        }

        public Observable<Unit> MoveScreenSuccessAsObservable => _moveScreenSuccess;
        private Subject<Unit> _moveScreenSuccess = new Subject<Unit>();

        public Observable<Unit> MoveScreenBattleSelectAsObservable => _moveScreenBattleSelect;
        private Subject<Unit> _moveScreenBattleSelect = new Subject<Unit>();

        private void EndTap()
        {
            if (_isGameEndSuccess)
            {
                //success
                _moveScreenSuccess.OnNext(Unit.Default);
            }
            else
            {
                //failure
                _moveScreenBattleSelect.OnNext(Unit.Default);
            }

            InitializeGame();
        }

        //Enemy
        public ReadOnlyReactiveProperty<Enemy> SelectEnemy => _selectEnemy;
        private ReactiveProperty<Enemy> _selectEnemy = new ReactiveProperty<Enemy>();
        public void SelectEnemyForceNotify()
        {
            _selectEnemy.ForceNotify();
        }

        public EnemyDropItem[] GetEnemyDrop()
        {
            var dropItems = _selectEnemy.Value.DropItem();
            return dropItems;
        }

        public void BattleSelect(Enemy enemy)
        {
            _selectEnemy.Value = enemy;
        }

        public void OnTapBattlePanel(int battleDamage)
        {
            switch (_battlePhase)
            {
                case BattlePhase.Start:
                    StartGame();
                    break;

                case BattlePhase.Battle:
                    Enemy enemy = new Enemy(_selectEnemy.Value.ID, _selectEnemy.Value.Name, _selectEnemy.Value.HitPoint, _selectEnemy.Value.DropItems);
                    enemy.HitPointMinus(battleDamage);
                    _selectEnemy.Value = enemy;

                    if (_selectEnemy.Value.HitPoint <= 0)
                    {
                        EndGame();
                    }
                    break;

                case BattlePhase.End:
                    EndTap();
                    break;
            }
        }

        public void OnTapBattleResultPanel()
        {
            _moveScreenBattleSelect.OnNext(Unit.Default);
        }
    }
}
