using UnityEngine;
using Zenject;

namespace My.ClickerGame
{
    public class BattleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("BattleInstaller run");

            //Presenter
            Container.Bind<BattlePresenter>().AsSingle();


            //Model
            Container.Bind<BattleModel>().AsSingle();

            //Service
            Container.Bind<BattleService>().AsSingle();
        }
    }
}
