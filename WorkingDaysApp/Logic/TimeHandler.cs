﻿using System;
using System.Globalization;

namespace WorkingDaysApp.Logic
{
    static public class TimeHandler
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
           var ci= CultureInfo.CreateSpecificCulture("en");
           return ci.DateTimeFormat.GetMonthName(monthInt);
        }

        public static string calcTime(string i_FirstTime, string i_SecondTime)
        {
            string[] firstTime = i_FirstTime.Split(':');
            string[] secondTime = i_SecondTime.Split(':');
            if (firstTime.Length > 1 && secondTime.Length > 1)
            {
                TimeSpan firsTimeSpan = new TimeSpan(int.Parse(firstTime[0]), int.Parse(firstTime[1]),
                    int.Parse(firstTime[2]));
                TimeSpan secondTimeSpan = new TimeSpan(int.Parse(secondTime[0]), int.Parse(secondTime[1]),
                    int.Parse(secondTime[2]));
                TimeSpan time = secondTimeSpan - firsTimeSpan;
                return time.ToString();
            }

            return "";
        }

        public static int getWeekDayInt(int year, int month, int monthDay)
        {
            DateTime dateValue = new DateTime(year, month, monthDay);
            return (int)dateValue.DayOfWeek;   
        }

        public static string getWeekDayStr(int year, int month, int monthDay)
        {
            DateTime dateValue = new DateTime(year, month, monthDay);
            return dateValue.DayOfWeek.ToString();
        }
    }
}