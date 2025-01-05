using UnityEngine;
using Zenject;

namespace My.ClickerGame
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("EnemyInstaller run");

            //Presenter
            Container.Bind<EnemyPresenter>().AsSingle();


            //Model
            Container.Bind<EnemyModel>().AsSingle();
        }
    }
}
