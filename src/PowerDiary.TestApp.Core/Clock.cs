using System;

namespace PowerDiary.TestApp.Core
{
    public class Clock
    {
        public static DateTime Now => DateTime.Now;

        public static DateTime GetTimeDate(int hour, int minute = 0, int second = 0)
        {
            return new DateTime(Now.Year, Now.Month, Now.Day, hour, minute, second);
        }

        public static DateTime GetTimeDate(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
        {
            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
