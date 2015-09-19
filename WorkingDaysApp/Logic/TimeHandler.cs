using System;
using System.Globalization;
using TimeWatchApp.Enums;

namespace WorkingDaysApp.Logic
{
    public static class TimeHandler
    {
        public static int CurYear()
        {
            DateTime dt = DateTime.Now;
            return dt.Year;
        }

        public static int NextYear()
        {
            return CurYear() + 1;
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

        public static int? DaysInMonth(int i_Year, int i_Month)
        {
            if (i_Month < 1 || i_Month > 12) return null;
            return DateTime.DaysInMonth(i_Year, i_Month);
        }

        public static string getCurrClockTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetMonthName(int i_MonthInt)
        {
            if (i_MonthInt < 1 || i_MonthInt > 12) return null;
            var ci = CultureInfo.CreateSpecificCulture("en");
            return ci.DateTimeFormat.GetMonthName(i_MonthInt);
        }

        public static string calcTime(string i_FirstTime, string i_SecondTime)
        {
            string[] firstTime = i_FirstTime.Split(':');
            string[] secondTime = i_SecondTime.Split(':');
            if (firstTime.Length > 1 && secondTime.Length > 1)
            {
                TimeSpan firsTimeSpan = new TimeSpan(Int32.Parse(firstTime[0]), Int32.Parse(firstTime[1]),
                    Int32.Parse(firstTime[2]));
                TimeSpan secondTimeSpan = new TimeSpan(Int32.Parse(secondTime[0]), Int32.Parse(secondTime[1]),
                    Int32.Parse(secondTime[2]));
                TimeSpan time = secondTimeSpan - firsTimeSpan;
                return time.ToString();
            }

            return "";
        }

        public static int getWeekDayInt(int i_Year, int i_Month, int i_MonthDay)
        {
            DateTime dateValue = new DateTime(i_Year, i_Month, i_MonthDay);
            return (int) dateValue.DayOfWeek;
        }

        public static string getWeekDayStr(int i_Year, int i_Month, int i_MonthDay)
        {
            DateTime dateValue = new DateTime(i_Year, i_Month, i_MonthDay);
            return dateValue.DayOfWeek.ToString();
        }

        public static string totalWorkingHoursInDay(string[] i_LineArr)
        {
            return calcTime(i_LineArr[(int) eColumn.Arrival], i_LineArr[(int) eColumn.Leaving]);
        }

        public static float dayWorkScope(string[] i_DayArr)
        {
            string totalDay = totalWorkingHoursInDay(i_DayArr);
            int minutes = getMinutes(totalDay);

            if (minutes >= TimeWatch.FULL_DAY_MINUTES) return 1.0f;
            if (minutes >= TimeWatch.HALF_DAY_MINUTES) return 0.5f;
            return 0.0f;
        }

        public static int getMinutes(string i_Time)
        {
            TimeSpan toReturn;
            TimeSpan.TryParse(i_Time, out toReturn);
            return (int) toReturn.TotalMinutes;
        }

        public static TimeSpan getDailyTotalHours(string[] i_DayArr)
        {
            TimeSpan toReturn;
            string totalDay = totalWorkingHoursInDay(i_DayArr);
            TimeSpan.TryParse(totalDay, out toReturn);
            return toReturn;
        }

        public static string getHoursStr(string i_ClockTime)
        {
            string[] timeArr = i_ClockTime.Split(':');
            return timeArr.Length > 1 ? timeArr [0]: "";
        }

        public static string getMinutesStr(string i_ClockTime)
        {
            string[] timeArr = i_ClockTime.Split(':');
            return timeArr.Length > 1 ? timeArr[1] : "";
        }
    }
}