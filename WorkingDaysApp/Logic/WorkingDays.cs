using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WorkingDaysApp.Logic
{
    public delegate void SetArrivalDelegate();
    public delegate void ShowYears(List<string> yearsList);
    public delegate void ShowMonth();

    public class WorkingDays
    {
        public event SetArrivalDelegate ArrivalEvent;
        public event SetArrivalDelegate LeavingEvent;
        public event ShowYears ShowYearsEvent;

        private List<FileInfo> AllFiles;

        public void start()
        {
            setAllFiles();
        }

        public List<string> getFileLines(int Year, int Month)
        {
            string filePath = getMonthsFilesPath() + "\\" + buildFileName(Year, Month);

            if (!File.Exists(filePath))
            {
                File.WriteAllLines(filePath, new []{""});
            }

            List<string> fileLines = new List<string>(File.ReadAllLines(filePath, Encoding.UTF8));
            
            return fileLines;
        }

        public List<string> GetYears()
        {
            List<string> years = new List<string>();
            setAllFiles();

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

        public void addCurrentArrivalTime()
        {
            List<string> fileLines = getFileLines(TimeHandler.CurYear(), TimeHandler.CurMonth());
            int lineToChange = -1;
            for (int i = 0; i < fileLines.Count ; i++)
            {
                string[] lineArr = fileLines[i].Split('-');

                if(lineArr.Length < 2) continue;

                if (int.Parse(lineArr[1]) == TimeHandler.CurDay())
                {
                    DialogResult toSetNow = MessageBox.Show("Arival already set.\nSet now instead?", @"Set Arrival", MessageBoxButtons.YesNo);
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
                    "Working Day",
                    TimeHandler.CurDay(),
                    TimeHandler.getCurrClockTime(), "_")
                    );
            }

            File.WriteAllLines(getMonthsFilesPath() + "\\" + buildFileName(TimeHandler.CurYear(), TimeHandler.CurMonth()), fileLines.ToArray());
        }

        private string setLineArrival(string i_FileLine)
        {
            string[] lineArr = i_FileLine.Split('-');
            lineArr[2] = TimeHandler.getCurrClockTime();
            return String.Format("{0}-{1}-{2}-{3}-{4}", lineArr[0], lineArr[1], lineArr[2], lineArr[3], lineArr[4]);
        }


        private string buildFileName(int Year, int Month)
        {
            return Year + "-" + (Month <= 9 ? "0" : "") + Month + ".txt";
        }
        
        private void setAllFiles()
        {
            AllFiles = new List<FileInfo>(new DirectoryInfo(getMonthsFilesPath()).GetFiles("*"));
        }

        private string getMonthsFilesPath()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\monthFiles";
        }

    }
}
