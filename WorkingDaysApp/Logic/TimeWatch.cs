using System.Collections.Generic;
using System.IO;
using WorkingDaysApp.Logic.TimeData;

namespace WorkingDaysApp.Logic
{
    public class TimeWatch
    {
        private static readonly TimeWatch sr_Instance = new TimeWatch();
        private MonthData m_CurrMonth;
        private static Dictionary<string, MonthData> s_AllMonthes;

        public event ChangeWasMade Changed;

        public static readonly char sr_RowSeparator = '-';
        public static readonly string sr_RowSeparatorStr = sr_RowSeparator.ToString();
        public static readonly string sr_DashReplacer = "%%";
        public const int FULL_DAY_MINUTES = 6 * 60;
        public const int HALF_DAY_MINUTES = 2 * 60;

        public static TimeWatch Instance
        {
            get
            {
                s_AllMonthes = new Dictionary<string, MonthData>();
                foreach (FileInfo file in FilesHandler.GetAllFiles())
                {
                    MonthData temp = new MonthData(file);
                    temp.Changed += sr_Instance.change_EventHandler;
                    s_AllMonthes.Add(file.Name, temp);
                }

                return sr_Instance;
            }
        }

        public Summary CurrSummary
        {
            get
            {
                return m_CurrMonth.Summary;
            }
        }

        public MonthData CurrMonth
        {
            get { return m_CurrMonth; }
            private set { m_CurrMonth = value; }
        }

        public int Year
        {
            get { return m_CurrMonth.Year; }
        }

        public int Month
        {
            get { return m_CurrMonth.Month; }
        }

        public List<DayData> AllDays
        {
            get { return m_CurrMonth.AllDays; }
        }

        public void UpdateCurrMonth(int i_Year, int i_Month)
        {
            string fileName = FilesHandler.BuildFileName(i_Year, i_Month);
            if (s_AllMonthes.ContainsKey(fileName)) CurrMonth = s_AllMonthes[fileName];
            else
            {
                MonthData temp = new MonthData(i_Year, i_Month);
                temp.Changed += change_EventHandler;
                s_AllMonthes.Add(fileName, temp);
                CurrMonth = s_AllMonthes[fileName];
            }

            change_EventHandler();
        }

        public void ChangeCurrMonth(int i_Month)
        {
            UpdateCurrMonth(CurrMonth.Year, i_Month);
        }

        public void ChangeCurrYear(int i_Year)
        {
            UpdateCurrMonth(i_Year, CurrMonth.Month);
        }

        private void change_EventHandler()
        {
            if (Changed != null) Changed.Invoke();
        }
    }
}