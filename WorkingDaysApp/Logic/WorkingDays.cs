﻿using System;
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
        
        public event ChangeWasMade Changed;

        public const char ROW_SEPARATOR = '-'; // Todo:  make sure no '-' is in comment
        public const int FULL_DAY_MINUTES = 6 * 60;
        public const int Half_DAY_MINUTES = 2 * 60;
        
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
                Changed.Invoke();
            }
        }

        public int ChosenYearInt 
        {
            get { return m_ChosenYearInt;}
            set
            {
                m_ChosenYearInt = value;
                Changed.Invoke();
            }
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

        private string dayDataArrTostring(string[] dayDataToSetArr)
        {
            return String.Format(ROW_FORMAT, dayDataToSetArr[0], dayDataToSetArr[1], dayDataToSetArr[2], dayDataToSetArr[3],
                dayDataToSetArr[4], dayDataToSetArr[5], dayDataToSetArr[6], ROW_SEPARATOR);
        }

        public string[] GetSummaryArr()
        {
            Array values = Enum.GetValues(typeof (eSummaryFeilds));
            string[] summaryArr = new string[values.Length], dayArr;
            TimeSpan sum = TimeSpan.Parse("00:00");
            float workingDays = 0, sickDays = 0, vacationDays = 0, holidays = 0;


            List<string> month = FilesHandler.GetFileLines(ChosenYearInt, ChosenMonthInt);
            foreach (string day in month)
            {
                dayArr = day.Split(ROW_SEPARATOR);

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
            if (minutes > Half_DAY_MINUTES) return 0.5f;
            return 0.0f;
        }
    }
}