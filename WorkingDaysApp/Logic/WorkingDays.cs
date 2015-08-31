using System.Collections.Generic;
using System.IO;
using System.Text;

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
        public event ShowMonth ShowMonthsEvent;

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

        public void SetYears()
        {
            List<string> years = new List<string>();
            setAllFiles();

            foreach (var file in AllFiles)
            {
                string curYear = file.Name.Split('-')[0];
                string curMonth = file.Name.Split('-')[1];
                if (!years.Contains(curYear))
                {
                    years.Add(curYear);
                }
            }
            ShowYearsEvent(years);
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
