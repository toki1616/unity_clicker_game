using UnityEngine;
using Zenject;

namespace My.Lifecycle
{
    public class AppLifecycleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Debug.Log("AppLifecycleInstaller run");

            //ViewModel
            Container.Bind<AppLifecycleViewModel>().AsSingle();


            //Model
            Container.Bind<AppLifecycleModel>().AsSingle();
        }
    }
}