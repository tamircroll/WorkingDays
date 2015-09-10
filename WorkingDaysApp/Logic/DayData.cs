using System.Windows.Forms;
using WorkingDaysApp.Logic.HourData;

namespace WorkingDaysApp.Logic
{
    public class DayData
    {
        private string m_MonthDay, m_WeekDay, m_Comment;
        private DayTimeData m_ArrivalTime, m_EndTime;

        public DayData(string i_MonthDay, string i_WeekDay, DayTimeData i_ArrivalTime, DayTimeData i_EndTime, string i_Comment)
        {
            m_MonthDay = i_MonthDay;
            m_WeekDay = i_WeekDay;
            m_Comment = i_Comment;
            m_ArrivalTime = i_ArrivalTime;
            m_EndTime = i_EndTime;
        }

        public string MonthDay
        {
            get { return m_MonthDay; }
        }

        public string WeekDay
        {
            get { return m_WeekDay; }
        }

        public string Comment
        {
            get { return m_Comment; }
            set { m_Comment = value; }
        }

        public DayTimeData ArrivalTime
        {
            get { return m_ArrivalTime; }
            set
            {
                if (string.IsNullOrEmpty(m_ArrivalTime.Time) && askIfToChangeData())
                    m_ArrivalTime = value;
            }
        }

        public DayTimeData EndTime
        {
            get { return m_EndTime; }
            set { m_EndTime = value; }
        }

        public string TotalHoursStr()
        {
            return EndTime.Subtract(ArrivalTime);
        }

        public string TotalMinutesStr()
        {
            return null;
        }















        private static bool askIfToChangeData()
        {
            return MessageBox.Show(
                @"Arival already set.
Set current time instead?",
                @"Set Time",
                MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

    }
}
