using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using TimeWatchApp.Enums;
using TimeWatchApp.Logic;

namespace WorkingDaysApp.Logic
{
    public delegate void ChangeWasMade();

    public class TimeWatch
    {
        static readonly TimeWatch sr_Instance = new TimeWatch();
        
        public event ChangeWasMade Changed;

        public static readonly char ROW_SEPARATOR = '-';
        public static readonly string DASH_REPLACER = "%%";
        public const int FULL_DAY_MINUTES = 6 * 60;
        public const int HALF_DAY_MINUTES = 2 * 60;
        
        public const string WORKING_DAY = "Working day", ROW_FORMAT = "{0}{7}{1}{7}{2}{7}{3}{7}{4}{7}{5}{7}{6}";
        
        private int m_ChosenYearInt, m_ChosenMonthInt;

        public static TimeWatch Instance
        {
            get { return sr_Instance; }
        }

        private TimeWatch()
        {
        }

        public int ChosenMonthInt
        {
            get { return m_ChosenMonthInt; }
            set
            {
                if (value != m_ChosenMonthInt)
                {
                    m_ChosenMonthInt = value;
                    if (Changed != null) Changed.Invoke();
                }
            }
        }

        public int ChosenYearInt 
        {
            get { return m_ChosenYearInt;}
            set
            {
                if (value != m_ChosenYearInt)
                {
                    m_ChosenYearInt = value;
                    if (Changed != null) Changed.Invoke();
                }
            }
        }
        
        public void SetTime(int i_MonthDay, eColumn i_Column, string i_TimeToSet)
        {
            int lineToEdit = i_MonthDay - 1;
            List<string> fileLines = FilesHandler.GetFileLines(m_ChosenYearInt, m_ChosenMonthInt);
            string[] lineArr = fileLines[lineToEdit].Split(ROW_SEPARATOR);

            if (i_Column == eColumn.Arrival && lineArr[(int)i_Column] != "" && !toChangeData()) return;
            setCellData(lineToEdit, i_Column, i_TimeToSet);
        }

        public void setCellData(int i_RowToSet, eColumn i_ColumnToSet, string i_DataToSet)
        {
            List<string> fileLines = FilesHandler.GetFileLines(m_ChosenYearInt, m_ChosenMonthInt);
            string[] dayDataToSetArr = fileLines[i_RowToSet].Split(ROW_SEPARATOR);
            
            dayDataToSetArr[(int) i_ColumnToSet] = i_DataToSet;
            fileLines[i_RowToSet] = dayDataArrTostring(dayDataToSetArr);
            File.WriteAllLines(FilesHandler.BuildFilePath(ChosenYearInt, ChosenMonthInt), fileLines.ToArray());

            if (Changed != null) Changed.Invoke();
        }

        private static bool toChangeData()
        {
            return MessageBox.Show(
                @"Arival already set.
Set current time instead?",
                @"Set Time",
                MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private string dayDataArrTostring(string[] i_DayDataToSetArr)
        {
            for (int i = 0 ; i < i_DayDataToSetArr.Length ; i++)
            {
                i_DayDataToSetArr[i] = i_DayDataToSetArr[i].Replace(ROW_SEPARATOR.ToString(), DASH_REPLACER);
            }
            return String.Format(ROW_FORMAT, i_DayDataToSetArr[0], i_DayDataToSetArr[1], i_DayDataToSetArr[2], i_DayDataToSetArr[3],
                i_DayDataToSetArr[4], i_DayDataToSetArr[5], i_DayDataToSetArr[6], ROW_SEPARATOR);
        }

        public string[] GetSummaryArr()
        {
            Array values = Enum.GetValues(typeof (eSummaryFeilds));
            string[] summaryArr = new string[values.Length];
            TimeSpan sum = TimeSpan.Parse("00:00");
            float workingDays = 0, sickDays = 0, vacationDays = 0, holidays = 0;


            List<string> month = FilesHandler.GetFileLines(ChosenYearInt, ChosenMonthInt);
            foreach (string day in month)
            {
                string[] dayArr = day.Split(ROW_SEPARATOR);

                sum += TimeHandler.getDailyTotalHours(dayArr);
                workingDays += getDailyWorkScope(dayArr);
                holidays += holidayScope(dayArr[(int)eColumn.DayType]);
                sickDays += dayArr[(int) eColumn.DayType] == DayTypeFactory.Get(eDayType.SickDay) ? 1 : 0;
                vacationDays += dayArr[(int) eColumn.DayType] == DayTypeFactory.Get(eDayType.PersonalVacation) ? 1 : 0;
            }

            summaryArr[(int)eSummaryFeilds.WorkingHours] = sum.ToString();
            summaryArr[(int)eSummaryFeilds.WorkingDays] = workingDays.ToString(CultureInfo.InvariantCulture);
            summaryArr[(int)eSummaryFeilds.SickDays] = sickDays.ToString(CultureInfo.InvariantCulture);
            summaryArr[(int)eSummaryFeilds.PersonalVecation] = vacationDays.ToString(CultureInfo.InvariantCulture);
            summaryArr[(int)eSummaryFeilds.Holidays] = holidays.ToString(CultureInfo.InvariantCulture);
            
            return summaryArr;
        }

        private float holidayScope(string i_DayType)
        {
            if (i_DayType == DayTypeFactory.Get(eDayType.Holiday)) return 1.0f;
            if (i_DayType == DayTypeFactory.Get(eDayType.HalfDay)) return 0.5f;
            return 0.0f;
        }

        public float getDailyWorkScope(string[] i_DayArr)
        {
            string totalDay = TimeHandler.totalWorkingHoursInDay(i_DayArr);
            int minutes = TimeHandler.getMinutes(totalDay);

            if (minutes > FULL_DAY_MINUTES) return 1.0f;
            if (minutes > HALF_DAY_MINUTES) return 0.5f;
            return 0.0f;
        }
    }
}