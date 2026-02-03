using System;
using My.Utils;

[Serializable]
public class AppExitData
{
    public string lastExitTime;
    
    public AppExitData()
    {
        lastExitTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}