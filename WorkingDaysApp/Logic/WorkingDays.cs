using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WorkingDaysApp.Enums;

namespace WorkingDaysApp.Logic
{
    public class WorkingDays
    {
        public const char ROW_SEPARATOR = '-';
        public const string WORKING_DAY = "Working day";
        public const string HOLIDAY = "Holiday";
        public const string HALF_DAY = "Half day";
        public const string ROW_FORMAT = "{0}{6}{1}{6}{2}{6}{3}{6}{4}{6}{5}";

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

            return years;
        }

        public void SetTime(int year, int month, int day, eColumn column, string timeToSet)
        {
            int lineToChange = day - 1;
            List<string> fileLines = FilesHandler.GetFileLines(year, month);
            string[] lineArr = fileLines[lineToChange].Split(ROW_SEPARATOR);
            if (column == eColumn.Arrival && lineArr[lineToChange] != "" && !toChangeData()) return;
            setRowClockTime(fileLines, lineToChange, column, timeToSet);
            File.WriteAllLines(FilesHandler.BuildFilePath(TimeHandler.CurYear(), TimeHandler.CurMonth()), fileLines.ToArray());
        }
        
        private void setRowClockTime(List<string> i_FileLines, int i_LineToChange, eColumn i_Column, string i_TimeToSet)
        {
            string[] lineArr = i_FileLines[i_LineToChange].Split(ROW_SEPARATOR);
            lineArr[(int)i_Column] = i_TimeToSet;
            lineArr[(int) eColumn.Day] = TimeHandler.CurDay().ToString();
            i_FileLines[i_LineToChange] = String.Format(ROW_FORMAT, lineArr[0], lineArr[1], lineArr[2], lineArr[3], lineArr[4], lineArr[5], ROW_SEPARATOR);
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
