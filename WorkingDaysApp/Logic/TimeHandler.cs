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

        public static int DaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }
    }
}