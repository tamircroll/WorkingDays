﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeWatchApp.Enums;
using TimeWatchApp.Logic;

namespace WorkingDaysApp.Logic.TimeData
{
    public delegate void ChangeWasMade();

    public class DayData
    {
        public event ChangeWasMade Changed;

        static readonly public char sr_Seperator = '-';
        public static string m_RowFormat = "{0}{7}{1}{7}{2}{7}{3}{7}{4}{7}{5}{7}{6}";

        private readonly string m_WeekDay, m_MonthDay;
        private string m_Comment = "";
        private TimeData m_ArrivalTime, m_LeavingTime;
        private eDayType m_DayType;

        public DayData(string i_MonthDay, string i_WeekDay, TimeData i_ArrivalTime, TimeData i_LeavingTime, eDayType i_DayType, string i_Comment)
        {
            m_MonthDay = i_MonthDay;
            m_WeekDay = i_WeekDay;
            m_ArrivalTime = i_ArrivalTime;
            m_LeavingTime = i_LeavingTime;
            m_Comment = i_Comment;
            m_DayType = i_DayType;
        }

        public DayData(string allData)
        {
            string[] sllDataArr = allData.Split(sr_Seperator);
            m_MonthDay = setMonthDay(sllDataArr[(int)eColumn.MonthDay]);
            m_WeekDay = sllDataArr[(int)eColumn.WeekDay];
            m_ArrivalTime = new TimeData(sllDataArr[(int)eColumn.Arrival]);
            m_LeavingTime = new TimeData(sllDataArr[(int)eColumn.Leaving]);
            m_DayType = DayTypeFactory.Get(sllDataArr[(int)eColumn.DayType]);
            m_Comment = sllDataArr[(int)eColumn.Comment];
        }

        public DayData(string i_MonthDay, string i_WeekDay, string i_DayType)
        {
            m_MonthDay = i_MonthDay;
            m_WeekDay = i_WeekDay;
            m_DayType = DayTypeFactory.Get(i_DayType);
            m_ArrivalTime = new TimeData();
            m_LeavingTime = new TimeData();
        }

        public string MonthDay
        {
            get { return m_MonthDay; }
        }

        public eDayType DayType
        {
            get { return m_DayType; }
            set
            {
                m_DayType = value;
                if (Changed != null) Changed.Invoke();
            }
        }

        public void setDayType(string i_DayTypeStr)
        {
            DayType = DayTypeFactory.Get(i_DayTypeStr);
            if (Changed != null) Changed.Invoke();
        }


        public string WeekDay
        {
            get { return m_WeekDay; }
        }

        public string Comment
        {
            get { return m_Comment; }
            set
            {
                m_Comment = value.Replace(TimeWatch.sr_RowSeparatorStr, TimeWatch.sr_DashReplacer);
                if (Changed != null) Changed.Invoke();
            }
        }

        public TimeData ArrivalTime
        {
            get { return m_ArrivalTime; }
            set
            {
                if (string.IsNullOrEmpty(m_ArrivalTime.Time))
                    m_ArrivalTime = value;
                else if(askIfToChangeData())
                    m_ArrivalTime = value;
                if (Changed != null) Changed.Invoke();
            }
        }

        public TimeData LeavingTime
        {
            get { return m_LeavingTime; }
            set
            {
                m_LeavingTime = value;
                if (Changed != null) Changed.Invoke();
            }
        }

        public string TotalHoursStr()
        {
            if (!LeavingTime.isTimeSet() || !ArrivalTime.isTimeSet()) return "";
            return LeavingTime.Subtract(ArrivalTime);
        }

        public int TotalMinutesStr()
        {
            return TotalSecondsStr()/60;
        }

        public int TotalSecondsStr()
        {
            TimeSpan toReturn;
            TimeSpan.TryParse(TotalHoursStr(), out toReturn);
            return (int)toReturn.TotalSeconds;
        }

        public override string ToString()
        {
            return string.Format(m_RowFormat, MonthDay, WeekDay, ArrivalTime, LeavingTime, TotalHoursStr(), DayTypeFactory.Get(DayType), Comment, TimeWatch.sr_RowSeparatorStr);
        }

        private string setMonthDay(string i_Day)
        {
            return (i_Day.Length == 1) ? "0" + i_Day : i_Day;
        }

        private static bool askIfToChangeData()
        {
            return MessageBox.Show(
                @"Arival already set.
Set current time instead?",
                @"Set Time",
                MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        public static List<DayData> StringLstToDayDataLst(List<string> i_AllStrings)
        {
            List<DayData> allDays = new List<DayData>();
            foreach (string day in i_AllStrings)
            {
                allDays.Add(new DayData(day));
            }

            return allDays;
        }
    }
}