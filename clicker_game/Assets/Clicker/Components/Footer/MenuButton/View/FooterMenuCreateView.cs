using System;
using UnityEngine;
using My.ClickerGame.MyEnum;

namespace My.ClickerGame
{
    public class FooterMenuCreateView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _spawnPrefab;

        // Start is called before the first frame update
        void Start()
        {
            CreateFooterMenuButton();
        }

        private void CreateFooterMenuButton()
        {
            foreach (FooterMenuType value in Enum.GetValues(typeof(FooterMenuType)))
            {
                if (!(value == FooterMenuType.Home || value == FooterMenuType.BattleSelect)) return;

                GameObject spawnObject = Instantiate(_spawnPrefab, this.transform);
                spawnObject.GetComponent<FooterMenuButtonView>().SetFooterMenuType(value);
            }
        }
    }
}
