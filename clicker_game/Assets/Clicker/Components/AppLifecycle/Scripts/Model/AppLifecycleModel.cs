using System;
using UnityEngine;
using My.Save.Json;

namespace My.Lifecycle
{
    public class AppLifecycleModel
    {
        public void OnAppStart()
        {
            var data = Load();
            Debug.Log($"前回終了時刻 : {data.lastExitTime}");
            Debug.Log($"経過時間 : {data.GetBackgroundTime()}");
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

        public AppExitData Load()
        {
            return JsonSaveUtils.Load<AppExitData>(SaveKey.LastExitTime.ToString());
        }
    }
}
