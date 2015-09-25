using System;
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
        public const string Day_FORMAT = "{0}-{1}-{2}-{3}-{4}-{5}-{6}";

        private readonly string m_WeekDay, m_MonthDay;
        private string m_Comment = "";
        private HourData m_ArrivalTime, m_LeavingTime;
        private eDayType m_DayType;

        public DayData(string i_MonthDay, string i_WeekDay, HourData i_ArrivalTime, HourData i_LeavingTime, eDayType i_DayType, string i_Comment)
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
            m_ArrivalTime = new HourData(sllDataArr[(int)eColumn.Arrival]);
            m_LeavingTime = new HourData(sllDataArr[(int)eColumn.Leaving]);
            m_DayType = DayTypeFactory.Get(sllDataArr[(int)eColumn.DayType]);
            m_Comment = sllDataArr[(int)eColumn.Comment];
        }

        public DayData(string i_MonthDay, string i_WeekDay, string i_DayType)
        {
            m_MonthDay = i_MonthDay;
            m_WeekDay = i_WeekDay;
            m_DayType = DayTypeFactory.Get(i_DayType);
            m_ArrivalTime = new HourData();
            m_LeavingTime = new HourData();
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
                m_Comment = value.Replace(TimeWatch2.sr_RowSeparatorStr, TimeWatch2.sr_DashReplacer);
                if (Changed != null) Changed.Invoke();
            }
        }

        public HourData ArrivalTime
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

        public HourData LeavingTime
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
            TimeSpan toReturn;
            TimeSpan.TryParse(TotalHoursStr(),out toReturn);
            return (int)toReturn.TotalMinutes;
        }

        public override string ToString()
        {
            return string.Format(Day_FORMAT, MonthDay, WeekDay, ArrivalTime, LeavingTime, TotalHoursStr(), DayTypeFactory.Get(DayType), Comment);
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