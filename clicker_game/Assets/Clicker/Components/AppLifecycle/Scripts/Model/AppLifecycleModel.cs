using System;
using UnityEngine;
using My.Save.Json;

namespace My.Lifecycle
{
    public class AppLifecycleModel
    {
        public void OnAppStart()
        {
            
        }

        public void OnAppExit()
        {
            var data = new AppExitData
            {
                lastExitTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            
            Save(data);
        }
    
        public void Save(AppExitData data)
        {
            JsonSaveUtils.Save(SaveKey.LastExitTime.ToString(), data);
        }
    }
}
