using UnityEngine;
using Zenject;

namespace My.ClickerGame
{
    public class ScreenInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("ScreenInstaller run");

            //Presenter
            Container.Bind<ScreenPresenter>().AsSingle();

            //Model
            Container.Bind<ScreenModel>().AsSingle();
        }
    }
}
