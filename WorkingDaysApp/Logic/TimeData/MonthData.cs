using System.IO;
using TimeWatchApp.Enums;
using WorkingDaysApp.Logic.TimeData;



namespace WorkingDaysApp.Logic.HourData
{
    using System.Collections.Generic;

    public delegate void ChangeWasMade();


    public class MonthData
    {
        public event ChangeWasMade Changed;

        private readonly List<DayData> m_AllDays;
        private readonly int m_Year, m_Month;
        public int NumOfDays {
            get { return m_AllDays.Count; }
        }

        public MonthData(int i_Year, int i_Month)
        {
            m_Year = i_Year;
            m_Month = i_Month;
            m_AllDays = DayData.StringLstToDayDataLst(FilesHandler.GetFileLines(i_Year, i_Month));
            subscribeToAllDaysEvents();
        }

        public List<DayData> AllDays
        {
            get { return m_AllDays; }
        }

        public MonthData(FileInfo i_File)
        {
            m_Year = FilesHandler.getFileYear(i_File.Name);
            m_Month = FilesHandler.getFileMonth(i_File.Name);
            m_AllDays = DayData.StringLstToDayDataLst(FilesHandler.GetFileLines(m_Year, m_Month));
            subscribeToAllDaysEvents();
        }

        public DayData this[int i_Day]
        {
            get { return m_AllDays[i_Day - 1]; }
        }

        public int Year
        {
            get { return m_Year; }
        }

        public int Month
        {
            get { return m_Month; }
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

        public float TotalVacationsDay()
        {
            float sum = 0;
            foreach (DayData day in m_AllDays)
            {
                if(day.DayType == eDayType.PersonalVacation)
                sum++;
            }

            return sum;
        }

        public int TotalSickDays()
        {
            int sum = 0;
            foreach (DayData day in m_AllDays)
            {
                if (day.DayType == eDayType.SickDay)
                    sum++;
            }

            return sum;
        }

        public float TotalHolidays()
        {
            float sum = 0;
            foreach (DayData day in m_AllDays)
            {
                if (day.DayType == eDayType.Holiday) sum++;
                else if (day.DayType == eDayType.HalfHoliday) sum += 0.5f;
            }

            return sum;
        }

        public float TotalHours()
        {
            TimeData.HourData total = new TimeData.HourData();
            foreach (DayData day in m_AllDays)
            {
                if (day.DayType == eDayType.Holiday) sum++;
                else if (day.DayType == eDayType.HalfHoliday) sum += 0.5f;
            }

            return sum;
        }

        public List<string> getDaysStringList()
        {
            List<string> toWrite = new List<string>();
            foreach (DayData day in m_AllDays)
            {
                toWrite.Add(day.ToString());
            }
            return toWrite;
        }

        private static float dayWorkScope(DayData i_DayArr)
        {
            int minutes = i_DayArr.TotalMinutesStr();

            if (minutes >= TimeWatch.FULL_DAY_MINUTES) return 1.0f;
            if (minutes >= TimeWatch.HALF_DAY_MINUTES) return 0.5f;
            return 0.0f;
        }

        private void writeToFile()
        {
            List<string> toWrite = getDaysStringList();
            File.WriteAllLines(FilesHandler.BuildFilePath(Year, Month), toWrite.ToArray());
        }

        private void subscribeToAllDaysEvents()
        {
            foreach (DayData day in m_AllDays)
            {
                day.Changed += change_EventHandler;
            }
        }

        private void change_EventHandler()
        {
            writeToFile();
            if (Changed != null) Changed.Invoke();
        }

    }
}
