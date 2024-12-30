using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

namespace My.ClickerGame
{
    public class BattleModel
    {
        private const float baseTimeLimit = 30;

        public ReadOnlyReactiveProperty<float> RemainingTime => _remainingTime;
        private ReactiveProperty<float> _remainingTime = new ReactiveProperty<float>(baseTimeLimit);

        public ReadOnlyReactiveProperty<bool> IsGamePlaying => _isGamePlaying;
        private ReactiveProperty<bool> _isGamePlaying = new ReactiveProperty<bool>(false);

        public void StartGame()
        {
            _isGamePlaying.Value = true;
            _remainingTime.Value = baseTimeLimit;

            StartCountdown();
        }

        private void StartCountdown()
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .TakeUntil(_isGamePlaying.Where(x => !x))
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
            _isGamePlaying.Value = false;
        }

        //Enemy
        public ReadOnlyReactiveProperty<Enemy> SelectEnemy => _selectEnemy;
        private ReactiveProperty<Enemy> _selectEnemy = new ReactiveProperty<Enemy>();
        public void SelectEnemyForceNotify()
        {
            _selectEnemy.ForceNotify();
        }

        public void BattleSelect(Enemy enemy)
        {
            _selectEnemy.Value = enemy;
        }

        public void OnTapBattleDamage()
        {
            if (!_isGamePlaying.Value)
            {
                StartGame();
                return;
            }

            Debug.Log("OnTapBattleDamage");
            Enemy enemy = new Enemy(_selectEnemy.Value.ID, _selectEnemy.Value.Name, _selectEnemy.Value.HitPoint, _selectEnemy.Value.DropItems);
            enemy.HitPointMinus(10);
            _selectEnemy.Value = enemy;
        }
    }
}
