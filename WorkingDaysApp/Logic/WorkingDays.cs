using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WorkingDaysApp.Enums;

namespace WorkingDaysApp.Logic
{
    public class WorkingDays
    {
        private const char ROW_SEPARATOR = '-';
        private const string WORKING_DAY = "Working day";
        private const string HOLIDAY = "Holiday";
        private const string HALF_DAY = "Half day";

        private static readonly string ROW_FORMAT = 
            string.Format("{0}{6}{1}{6}{2}{6}{3}{6}{4}{6}{5}",
            "{0}", "{1}", "{2}", "{3}", "{4}","{5}", ROW_SEPARATOR);

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

        public void SetCurrentTime(eColumn columnToSetForNow)
        {
            List<string> fileLines = FilesHandler.GetFileLines(TimeHandler.CurYear(), TimeHandler.CurMonth());
            int? rowToChange = null;
            for (int i = 0; i < fileLines.Count; i++)  //TODO: first, to find the currect line - rowInt = findCurRow() -> setCurTime(eColumn) -> addDuration()
            {
                string[] lineArr = fileLines[i].Split(ROW_SEPARATOR);

                if (lineArr.Length < 2) continue;

                if (int.Parse(lineArr[0]) == TimeHandler.CurDay())
                {
                    if (columnToSetForNow == eColumn.Arrival && !toChangeData()) return;

                    rowToChange = i;
                }
            }

            if (rowToChange != null)
            {
                setRowForNow(fileLines, (int)rowToChange, columnToSetForNow);
            }
            else
            {
                fileLines.Add(string.Format("{0}{0}{0}{0}{0}", ROW_SEPARATOR));
                setRowForNow(fileLines, fileLines.Count - 1, columnToSetForNow);
            }

            File.WriteAllLines(FilesHandler.BuildFilePath(TimeHandler.CurYear(), TimeHandler.CurMonth()),
                fileLines.ToArray());
        }
        
        private void setRowForNow(List<string> i_FileLines, int i_LineToChange, eColumn i_Column)
        {
            string[] lineArr = i_FileLines[i_LineToChange].Split(ROW_SEPARATOR);
            lineArr[(int)i_Column] = TimeHandler.getCurrClockTime();
            lineArr[(int) eColumn.Day] = TimeHandler.CurDay().ToString();
            i_FileLines[i_LineToChange] = String.Format(ROW_FORMAT, lineArr[0], lineArr[1], lineArr[2], lineArr[3], lineArr[4], lineArr[5]);
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
