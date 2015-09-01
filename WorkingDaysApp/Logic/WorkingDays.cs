using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WorkingDaysApp.Logic
{
    public delegate void SetArrivalDelegate();

    public delegate void ShowYears(List<string> yearsList);

    public class WorkingDays
    {
        public event SetArrivalDelegate ArrivalEvent;
        public event SetArrivalDelegate LeavingEvent;
        public event ShowYears ShowYearsEvent;

        private List<FileInfo> AllFiles;

        public void start()
        {
            AllFiles = FilesHandler.GetAllFiles();
        }

        public List<string> getFileLines(int Year, int Month)
        {
            string filePath = FilesHandler.BuildFilePath(Year, Month);

            if (!File.Exists(filePath))
            {
                File.WriteAllLines(filePath, new[] {""});
            }

            List<string> fileLines = new List<string>(File.ReadAllLines(filePath, Encoding.UTF8));

            return fileLines;
        }


        public List<string> GetYears()
        {
            List<string> years = new List<string>();
            AllFiles = FilesHandler.GetAllFiles();

            foreach (var file in AllFiles)
            {
                string curYear = file.Name.Split('-')[0];
                if (!years.Contains(curYear))
                {
                    years.Add(curYear);
                }
            }

            return years;
        }

        public void SetCurrentArrivalTime()
        {
            List<string> fileLines = getFileLines(TimeHandler.CurYear(), TimeHandler.CurMonth());
            int lineToChange = -1;
            for (int i = 0; i < fileLines.Count; i++)
            {
                string[] lineArr = fileLines[i].Split('-');

                if (lineArr.Length < 2) continue;

                if (int.Parse(lineArr[0]) == TimeHandler.CurDay())
                {
                    DialogResult toSetNow = MessageBox.Show("Arival already set.\nSet now instead?", @"Set Arrival",
                        MessageBoxButtons.YesNo);
                    if (toSetNow == DialogResult.No) return;
                    lineToChange = i;
                }
            }

            if (lineToChange >= 0)
            {
                fileLines[lineToChange] = setLineArrival(fileLines[lineToChange]);
            }
            else
            {
                fileLines.Add(String.Format(
                    "{0}-{1}-{2}-{2}-{3}",
                    TimeHandler.CurDay(),
                    TimeHandler.getCurrClockTime(),
                    "Working Day",
                    "_")
                    );
            }

            File.WriteAllLines(FilesHandler.BuildFilePath(TimeHandler.CurYear(), TimeHandler.CurMonth()),
                fileLines.ToArray());
        }

        private string setLineArrival(string i_FileLine)
        {
            string[] lineArr = i_FileLine.Split('-');
            lineArr[1] = TimeHandler.getCurrClockTime();
            return String.Format("{0}-{1}-{2}-{3}-{4}", lineArr[0], lineArr[1], lineArr[2], lineArr[3], lineArr[4]);
        }
    }
}
