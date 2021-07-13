using System;

namespace API.PowerBI.Extensions
{
    public static class CommonExtensions
    {
        public static bool IsValid(this DateTime expiryTime)
        {
            bool isvalid = false;
            var currentTimeSpan = new TimeSpan(DateTime.Now.ToUniversalTime().TimeOfDay.Ticks);
            var expireTimeSpan = new TimeSpan(expiryTime.TimeOfDay.Ticks);
            if (expiryTime != null)
            {
                var time = TimeSpan.Compare(expireTimeSpan, currentTimeSpan);
                if (time == 1)
                {
                    isvalid = true;
                }
            }
            return isvalid;
        }
    }
}
