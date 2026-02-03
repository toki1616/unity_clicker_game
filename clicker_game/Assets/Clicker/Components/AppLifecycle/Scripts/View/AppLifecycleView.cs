using UnityEngine;
using Zenject;

namespace My.Lifecycle
{
    public class AppLifecycleView : MonoBehaviour
    {
        private AppLifecycleViewModel _appLifecycleViewModel;

        [Inject]
        public void Construct
            (
                AppLifecycleViewModel appLifecycleViewModel
            )
        {
            //Debug.Log("AppLifecycleView : Inject");
            _appLifecycleViewModel = appLifecycleViewModel;
        }

        void Awake()
        {
            _appLifecycleViewModel.OnAppStart();
        }

        void OnApplicationQuit()
        {
            _appLifecycleViewModel.OnAppExit();
        }

        void OnApplicationPause(bool pause)
        {
            if (pause)
                _appLifecycleViewModel.OnAppExit();
        }
    }
}