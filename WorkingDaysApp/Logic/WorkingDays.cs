using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using WorkingDaysApp.Enums;

namespace WorkingDaysApp.Logic
{
    public delegate void ChangeWasMade();

    public class WorkingDays
    {
        static readonly WorkingDays _instance = new WorkingDays();
        
        public event ChangeWasMade m_Changed;

        public const char ROW_SEPARATOR = '-'; // Todo:  make sure no '-' is in comment
        private const int FULL_DAY_MINUTES = 6 * 60;
        private const int Half_DAY_MINUTES = 2 * 60;
        
        public const string WORKING_DAY = "Working day",
            HOLIDAY = "Holiday",
            HALF_DAY = "Half day",
            ROW_FORMAT = "{0}{7}{1}{7}{2}{7}{3}{7}{4}{7}{5}{7}{6}";

        public static WorkingDays Instance
        {
            get { return _instance; }
        }

        private int m_ChosenYearInt = TimeHandler.CurYear(), 
            m_ChosenMonthInt = TimeHandler.CurMonth();

        public int ChosenMonthInt
        {
            get { return m_ChosenMonthInt; }
            set
            {
                m_ChosenMonthInt = value;
                m_Changed.Invoke();
            }
        }

        public int ChosenYearInt 
        {
            get { return m_ChosenYearInt;}
            set
            {
                m_ChosenYearInt = value;
                m_Changed.Invoke();
            }
        }

        private List<FileInfo> AllFiles;
        
        public void start()
        {
            AllFiles = FilesHandler.GetAllFiles();
        }
        
        public void SetTime(int monthDay, eColumn column, string timeToSet)
        {
            int lineToEdit = monthDay - 1;
            List<string> fileLines = FilesHandler.GetFileLines(m_ChosenYearInt, m_ChosenMonthInt);
            string[] lineArr = fileLines[lineToEdit].Split(ROW_SEPARATOR);

            if (column == eColumn.Arrival && lineArr[(int)column] != "" && !toChangeData()) return;
            setCellData(lineToEdit, column, timeToSet);
        }

        public void setCellData(int i_RowToSet, eColumn i_ColumnToSet, string i_DataToSet)
        {
            List<string> fileLines = FilesHandler.GetFileLines(m_ChosenYearInt, m_ChosenMonthInt);
            string[] dayDataToSetArr = fileLines[i_RowToSet].Split(ROW_SEPARATOR);
            
            dayDataToSetArr[(int) i_ColumnToSet] = i_DataToSet;
            fileLines[i_RowToSet] = dayDataArrTostring(dayDataToSetArr);
            File.WriteAllLines(FilesHandler.BuildFilePath(ChosenYearInt, ChosenMonthInt), fileLines.ToArray());

            if (m_Changed != null) m_Changed.Invoke();
        }

        private static bool toChangeData()
        {
            return MessageBox.Show(
                @"Arival already set.
Set current time instead?",
                @"Set Time",
                MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private string dayDataArrTostring(string[] dayDataToSetArr)
        {
            return String.Format(ROW_FORMAT, dayDataToSetArr[0], dayDataToSetArr[1], dayDataToSetArr[2], dayDataToSetArr[3],
                dayDataToSetArr[4], dayDataToSetArr[5], dayDataToSetArr[6], ROW_SEPARATOR);
        }

        public string[] getSummary()
        {
            string[] summaryArr = GetSummaryArr();

            summaryArr[(int)eSummaryFeilds.WorkingDays] = "Working Days: " + summaryArr[(int)eSummaryFeilds.WorkingDays];
            summaryArr[(int)eSummaryFeilds.MissingDays] = "Missing Days: " + summaryArr[(int)eSummaryFeilds.MissingDays];
            summaryArr[(int)eSummaryFeilds.SickDays] = "Sick Days: " + summaryArr[(int)eSummaryFeilds.SickDays];
            summaryArr[(int)eSummaryFeilds.VacationDays] = "Vacation Days: " + summaryArr[(int)eSummaryFeilds.VacationDays]; ;
            summaryArr[(int)eSummaryFeilds.WorkingHours] = "Working Hours: " + summaryArr[(int)eSummaryFeilds.WorkingHours]; ;

            return summaryArr;
        }

        public string[] GetSummaryArr()
        {
            Array values = Enum.GetValues(typeof (eSummaryFeilds));
            string[] summaryArr = new string[values.Length], dayArr;
            TimeSpan sum = TimeSpan.Parse("00:00");
            float workingDays = 0;


            List<string> month = FilesHandler.GetFileLines(ChosenYearInt, ChosenMonthInt);
            foreach (string day in month)
            {
                dayArr = day.Split(ROW_SEPARATOR);
                sum += dayHoursSummary(dayArr);
                workingDays += dayWork(dayArr);

            }

            summaryArr[(int) eSummaryFeilds.WorkingHours] = sum.ToString();
            summaryArr[(int) eSummaryFeilds.WorkingDays] = workingDays.ToString();
            return summaryArr;
        }

        private float dayWork(string[] i_DayArr)
        {
            string totalDay = totalWorkingInDay(i_DayArr);
            int minutes = getMinutes(totalDay);

            if (minutes > FULL_DAY_MINUTES) return 1.0f;
            if (minutes > Half_DAY_MINUTES) return 0.5f;

            return 0.0f;
        }

        private int getMinutes(string time)
        {
            TimeSpan toReturn;
            TimeSpan.TryParse(time, out toReturn);
            return (int)toReturn.TotalMinutes;
        }

        private static TimeSpan dayHoursSummary(string[] i_DayArr)
        {
            TimeSpan toReturn;
            string totalDay = totalWorkingInDay(i_DayArr);
            TimeSpan.TryParse(totalDay, out toReturn);
            return toReturn;
        }

        private static string totalWorkingInDay(string[] lineArr)
        {
            return TimeHandler.calcTime(lineArr[(int) eColumn.Arrival], lineArr[(int) eColumn.Leaving]);
        }
    }
}