using UnityEngine;
using Zenject;

namespace My.ClickerGame
{
    public class ItemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("ItemInstaller run");

            //Presenter
            Container.Bind<ItemPresenter>().AsSingle();

            //Model
            Container.Bind<ItemModel>().AsSingle();
        }
    }
}
