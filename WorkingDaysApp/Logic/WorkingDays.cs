using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WorkingDaysApp.Enums;

namespace WorkingDaysApp.Logic
{
    public class WorkingDays
    {
        static readonly WorkingDays _instance = new WorkingDays();

        public const char ROW_SEPARATOR = '-';

        public const string WORKING_DAY = "Working day",
            HOLIDAY = "Holiday",
            HALF_DAY = "Half day",
            ROW_FORMAT = "{0}{7}{1}{7}{2}{7}{3}{7}{4}{7}{5}{7}{6}";

        public static WorkingDays Instance
        {
            get { return _instance; }
        }

        public int chosenYearInt, chosenMonthInt;

        private List<FileInfo> AllFiles;
        
        public void start()
        {
            AllFiles = FilesHandler.GetAllFiles();
        }

        public List<string> GetYears()
        {
            List<string> years = new List<string>();
            AllFiles = FilesHandler.GetAllFiles();

            foreach (var file in AllFiles)
            {
                string curYear = file.Name.Split(ROW_SEPARATOR)[0];
                if (!years.Contains(curYear))
                {
                    years.Add(curYear);
                }
            }
            if (!years.Contains(TimeHandler.NextYear().ToString())) years.Add(TimeHandler.NextYear().ToString());

            return years;
        }
        
        public void SetTime(int monthDay, eColumn column, string timeToSet)
        {
            int lineToEdit = monthDay - 1;
            List<string> fileLines = FilesHandler.GetFileLines(chosenYearInt, chosenMonthInt);
            string[] lineArr = fileLines[lineToEdit].Split(ROW_SEPARATOR);

            if (column == eColumn.Arrival && lineArr[(int)column] != "" && !toChangeData()) return;

            setCellData(fileLines, lineToEdit, column, timeToSet);
            File.WriteAllLines(FilesHandler.BuildFilePath(TimeHandler.CurYear(), TimeHandler.CurMonth()),
                fileLines.ToArray());
        }

        private void setCellData(List<string> i_FileLines, int i_RowToSet, eColumn i_ColumnToSet, string i_DataToSet)
        {
            string[] lineArr = i_FileLines[i_RowToSet].Split(ROW_SEPARATOR);
            lineArr[(int) i_ColumnToSet] = i_DataToSet;
            lineArr[(int) eColumn.MonthDay] = TimeHandler.CurDay().ToString();
            i_FileLines[i_RowToSet] = String.Format(ROW_FORMAT, lineArr[0], lineArr[1], lineArr[2], lineArr[3],
                lineArr[4], lineArr[5],lineArr[6], ROW_SEPARATOR);
        }



        public void setComment(List<string> i_FileLines, int i_RowToSet, eColumn i_ColumnToSet, string i_Msg)
        {
            
        }

        private static bool toChangeData()
        {
            return MessageBox.Show(
                @"Arival already set.
Set current time instead?",
                @"Set Time",
                MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
    }
}
