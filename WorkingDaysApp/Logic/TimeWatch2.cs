using System.Collections.Generic;
using System.IO;
using WorkingDaysApp.Logic.HourData;

namespace WorkingDaysApp.Logic.TimeData
{
    public class TimeWatch2
    {
        private static readonly TimeWatch2 sr_Instance = new TimeWatch2();
        
        private static Dictionary<string, MonthData> s_AllMonthes;

        public event ChangeWasMade Changed;

        public static readonly char sr_RowSeparator = '-';
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
                    s_AllMonthes.Add(file.Name, new MonthData(file));
                }

                return sr_Instance;
            }
        }

        public MonthData CurrMonth { get; set; }

        public void SetCurrMonth(int i_Year, int i_Month)
        {
            string fileName = FilesHandler.BuildFileName(i_Year, i_Month);
            if (s_AllMonthes.ContainsKey(fileName)) CurrMonth = s_AllMonthes[fileName];
            else
            {
                s_AllMonthes.Add(fileName, new MonthData(i_Year, i_Month));
                CurrMonth = s_AllMonthes[fileName];
            }
        }

        public void ChangeCurrMonth(int i_Month)
        {
            SetCurrMonth(CurrMonth.Month, i_Month);
        }

        public void ChangeCurrYear(int i_Year)
        {
            SetCurrMonth(i_Year, CurrMonth.Month);
        }
    }
}