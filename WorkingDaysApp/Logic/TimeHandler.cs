using System;
using System.Globalization;
using System.Windows.Forms;
using WorkingDaysApp.Enums;

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

        public static int DaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static string getCurrClockTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetMonthName(int monthInt)
        {
            var ci = CultureInfo.CreateSpecificCulture("en");
            return ci.DateTimeFormat.GetMonthName(monthInt);
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

        public static int getWeekDayInt(int year, int month, int monthDay)
        {
            DateTime dateValue = new DateTime(year, month, monthDay);
            return (int) dateValue.DayOfWeek;
        }

        public static string getWeekDayStr(int year, int month, int monthDay)
        {
            DateTime dateValue = new DateTime(year, month, monthDay);
            return dateValue.DayOfWeek.ToString();
        }

        public static string totalWorkingHoursInDay(string[] lineArr)
        {
            return calcTime(lineArr[(int) eColumn.Arrival], lineArr[(int) eColumn.Leaving]);
        }

        public static float dayWorkScope(string[] i_DayArr)
        {
            string totalDay = totalWorkingHoursInDay(i_DayArr);
            int minutes = getMinutes(totalDay);

            if (minutes >= WorkingDays.FULL_DAY_MINUTES) return 1.0f;
            if (minutes >= WorkingDays.Half_DAY_MINUTES) return 0.5f;
            return 0.0f;
        }

        public static int getMinutes(string time)
        {
            TimeSpan toReturn;
            TimeSpan.TryParse(time, out toReturn);
            return (int) toReturn.TotalMinutes;
        }

        public static TimeSpan getDailyTotalHours(string[] i_DayArr)
        {
            TimeSpan toReturn;
            string totalDay = totalWorkingHoursInDay(i_DayArr);
            TimeSpan.TryParse(totalDay, out toReturn);
            return toReturn;
        }

        public static string getHoursStr(string clockTime)
        {
            string[] timeArr = clockTime.Split(':');
            return timeArr.Length > 1 ? timeArr [0]: "";
        }

        public static string getMinutesStr(string clockTime)
        {
            string[] timeArr = clockTime.Split(':');
            return timeArr.Length > 1 ? timeArr[1] : "";
        }

    }
}