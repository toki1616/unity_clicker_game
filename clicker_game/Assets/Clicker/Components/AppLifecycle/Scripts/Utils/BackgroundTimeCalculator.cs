using System;

namespace My.Utils
{
    public static class BackgroundTimeCalculator
    {
        public static TimeSpan CalculateBackgroundTime(string lastExitTime)
        {
            if (string.IsNullOrEmpty(lastExitTime))
                return TimeSpan.Zero;

            if (!DateTime.TryParse(lastExitTime, out var exitTime))
                return TimeSpan.Zero;

            var now = DateTime.Now;
            return now - exitTime;
        }
    }
}