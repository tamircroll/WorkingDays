using System.Collections.Generic;
using System.IO;

namespace WorkingDaysApp.Logic.TimeData
{
    public class TimeWatch2
    {
        private static readonly TimeWatch2 sr_Instance = new TimeWatch2();
        private MonthData m_CurrMonth;
        private static Dictionary<string, MonthData> s_AllMonthes;

        public event ChangeWasMade Changed;

        public static readonly char sr_RowSeparator = '-';
        public static readonly string sr_RowSeparatorStr = sr_RowSeparator.ToString();
        public static readonly string sr_DashReplacer = "%%";
        public const int FULL_DAY_MINUTES = 6 * 60;
        public const int HALF_DAY_MINUTES = 2 * 60;

        public const string WORKING_DAY = "Working day", ROW_FORMAT = "{0}{7}{1}{7}{2}{7}{3}{7}{4}{7}{5}{7}{6}";


        public static TimeWatch2 Instance
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

        public MonthData CurrMonth
        {
            get { return m_CurrMonth; }
            private set { m_CurrMonth = value; }
        }

        public void SetCurrMonth(int i_Year, int i_Month)
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
            SetCurrMonth(CurrMonth.Year, i_Month);
        }

        public void ChangeCurrYear(int i_Year)
        {
            SetCurrMonth(i_Year, CurrMonth.Month);
        }

        private void change_EventHandler()
        {
            Changed.Invoke();
        }
    }
}