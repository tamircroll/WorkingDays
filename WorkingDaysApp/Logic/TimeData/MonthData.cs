using System.Collections.Generic;
using System.IO;
using TimeWatchApp.Enums;

namespace WorkingDaysApp.Logic.TimeData
{
    public class MonthData
    {
        public event ChangeWasMade Changed;

        private readonly Summary m_Summary;
        private readonly List<DayData> m_AllDays;
        private readonly int m_Year, m_Month;
        public int NumOfDays {
            get { return m_AllDays.Count; }
        }

        public MonthData(int i_Year, int i_Month)
        {
            m_Year = i_Year;
            m_Month = i_Month;
            m_Summary = new Summary(this);
            m_AllDays = DayData.StringLstToDayDataLst(FilesHandler.GetFileLines(i_Year, i_Month));
            subscribeToAllDaysEvents();
            change_EventHandler();
        }


        public MonthData(FileInfo i_File)
        {
            m_Summary = new Summary(this);
            m_Year = FilesHandler.getFileYear(i_File.Name);
            m_Month = FilesHandler.getFileMonth(i_File.Name);
            m_AllDays = DayData.StringLstToDayDataLst(FilesHandler.GetFileLines(m_Year, m_Month));
            subscribeToAllDaysEvents();
            change_EventHandler();
        }

        public List<DayData> AllDays
        {
            get { return m_AllDays; }
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

        public Summary Summary 
        {
            get { return m_Summary; }
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
