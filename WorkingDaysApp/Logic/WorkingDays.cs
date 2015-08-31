using System;
using System.Collections.Generic;
using System.IO;
using WorkingDaysApp.FormUI;

namespace WorkingDaysApp.Logic
{
    public delegate void SetArrivalDelegate(List<string> monthData);
    public delegate void ShowDates(List<string> yearsList);

    public class WorkingDays
    {
        public event SetArrivalDelegate arrivalEvent;
        public event ShowDates showYearsEvent;
        public event ShowDates showMonthsEvent;


        private List<FileInfo> AllFiles;

        public void start()
        {
            setAllFiles();
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
            showYearsEvent(years);
        }









        private void setAllFiles()
        {
            string project_path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\monthFiles";
            AllFiles = new List<FileInfo>(new DirectoryInfo(project_path).GetFiles("*"));

            //AllFiles = new List<string>(Directory.GetFiles(project_path));
        }


    }
}
