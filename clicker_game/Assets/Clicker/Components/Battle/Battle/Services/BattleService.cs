using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using My.ClickerGame.MyEnum;
using My.ClickerGame.Const;

namespace My.ClickerGame
{
    public class BattleService
    {
        private readonly EnemyModel _enemyModel;
        private readonly BattleModel _battleModel;
        private readonly ScreenModel _screenModel;
        private readonly ItemModel _itemModel;

        public BattleService
            (
            EnemyModel enemyModel,
            BattleModel battleModel,
            ScreenModel screenModel,
            ItemModel itemModel
            )
        {
            //Debug.Log("BattleService : Inject");
            _enemyModel = enemyModel;
            _battleModel = battleModel;
            _screenModel = screenModel;
            _itemModel = itemModel;
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

        public int GetBattleTapDamage()
        {
            var shotUpgrade = _itemModel.GetUpgradeableItemValue(UpgradeableItemType.Shot);
            var fighterJetCountUpgrade = _itemModel.GetUpgradeableItemValue(UpgradeableItemType.FighterJetCount);
            var supportUpgrade = _itemModel.GetUpgradeableItemValue(UpgradeableItemType.Support);

            int shotTapDamage = BattleConst.baseTapDamageShot * shotUpgrade.Level;
            int fighterJetTapDamage = BattleConst.baseTapDamageFighterJetCount * fighterJetCountUpgrade.Level;
            int supportTapDamage = BattleConst.baseTapDamageSupport * supportUpgrade.Level;

            int totalTapDamage = shotTapDamage + fighterJetTapDamage + supportTapDamage;

            return totalTapDamage;
        }

        public void AddBattleDropItem(EnemyDropItem[] dropItems)
        {
            foreach (var dropItem in dropItems)
            {
                _itemModel.AddUpgradeComponent(dropItem.DropItemType, dropItem.DropCount);
            }
        }
    }
}
