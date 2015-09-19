using System.IO;
using WorkingDaysApp.Logic.TimeData;

namespace WorkingDaysApp.Logic.HourData
{
    using System.Collections.Generic;

    public class MonthData
    {
        private List<DayData> m_AllDays;
        private int m_Year, m_Month;
        public int NumOfDays { get; private set; }

        public MonthData(int i_Year, int i_Month)
        {
            m_Year = i_Year;
            m_Month = i_Month;
            m_AllDays = new List<DayData>();
            setNumOfDays(i_Year, i_Month);
            createFileIfNeeded();
        }

        public MonthData(List<DayData> i_AllDays, int i_Year, int i_Month)
        {
            m_AllDays = i_AllDays;
            m_Year = i_Year;
            m_Month = i_Month;
            setNumOfDays(i_Year, i_Month);
        }

        public MonthData(List<string> i_AllDays, int i_Year, int i_Month)
        {
            m_AllDays = DayData.StringLstToDayDataLst(i_AllDays);
            m_Year = i_Year;
            m_Month = i_Month;
            setNumOfDays(i_Year, i_Month);
        }

        public MonthData(FileInfo i_File)
        {
            m_Year = FilesHandler.getFileYear(i_File.Name);
            m_Month = FilesHandler.getFileMonth(i_File.Name);
            m_AllDays = DayData.StringLstToDayDataLst(FilesHandler.GetFileLines(m_Year, m_Month));
        }

        public int Year
        {
            get { return m_Year; }
        }

        public int Month
        {
            get { return m_Month; }
        }

        public void addDay(DayData i_DayToAdd, int i_DayInMonth)
        {
            if (i_DayInMonth > NumOfDays || i_DayInMonth < NumOfDays)
                m_AllDays[i_DayInMonth - 1] = i_DayToAdd;
        }

        public float AllWorkingDays()
        {
            float sum = 0;
            foreach (DayData day in m_AllDays)
            {
                sum += dayWorkScope(day);
            }

            return sum;
        }


        private void setNumOfDays(int i_Year, int i_Month)
        {
            int? daysInMonth = TimeHandler.DaysInMonth(i_Year, i_Month);
            if (daysInMonth != null) NumOfDays = (int) daysInMonth;
        }

        private static float dayWorkScope(DayData i_DayArr)
        {
            int minutes = i_DayArr.TotalMinutesStr();

            if (minutes >= TimeWatch.FULL_DAY_MINUTES) return 1.0f;
            if (minutes >= TimeWatch.HALF_DAY_MINUTES) return 0.5f;
            return 0.0f;
        }
    }
}
