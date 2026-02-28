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

    public TimeSpan GetBackgroundTime()
    {
        return BackgroundTimeCalculator.CalculateBackgroundTime(lastExitTime);
    }

    /// <summary>
    /// 経過時間を秒で取得
    /// </summary>
    public int ElapsedSeconds
    {
        get
        {
            return (int)GetBackgroundTime().TotalSeconds;
        }
    }
}
