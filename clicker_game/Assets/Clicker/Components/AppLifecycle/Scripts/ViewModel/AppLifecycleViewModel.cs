using UnityEngine;

namespace My.Lifecycle
{
    public class AppLifecycleViewModel
    {
        private readonly AppLifecycleModel _appLifecycleModel;

        public AppLifecycleViewModel
            (
            AppLifecycleModel appLifecycleModel
            )
        {
            //Debug.Log("AppLifecycleViewModel : Inject");
            _appLifecycleModel = appLifecycleModel;
        }
    
        public void OnAppStart()
        {
            _appLifecycleModel.OnAppStart();
        }

        public void OnAppExit()
        {
            _appLifecycleModel.OnAppExit();
        }
    }
}
