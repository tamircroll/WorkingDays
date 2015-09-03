using System;
using System.Collections.Generic;
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

        public const char ROW_SEPARATOR = '-';

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
    }
}