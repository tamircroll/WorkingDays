using System;

namespace WorkingDaysApp.Logic
{
    static public class TimeHandler
    {
        public static int CurYear()
        {
            DateTime dt = DateTime.Now;
            return dt.Year;
        }

        public static int CurMonth()
        {
            DateTime dt = DateTime.Now;
            return dt.Month;
        }

        public static int CurDay()
        {
            DateTime dt = DateTime.Now;
            return dt.Day;
        }

        public static int CurHour()
        {
            DateTime dt = DateTime.Now;
            return dt.Hour;
        }

        public static int CurMinute()
        {
            DateTime dt = DateTime.Now;
            return dt.Minute;
        }

        public static int DaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static string getCurrClockTime()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }
    }
}