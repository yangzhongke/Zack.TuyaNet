using System;

namespace SmartHomeUI
{
    public static class TimeHelpers
    {
        /// <summary>
        /// 判断ts是否和当前时间处于同一个分钟之内
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static bool IsNow(this TimeSpan ts)
        {
            TimeSpan now = DateTime.Now.TimeOfDay;
            return now.Hours == ts.Hours && now.Minutes == ts.Minutes;
        }
    }
}
