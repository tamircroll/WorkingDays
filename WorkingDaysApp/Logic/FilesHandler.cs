using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TimeWatchApp.Enums;
using TimeWatchApp.Logic;

namespace WorkingDaysApp.Logic
{
    static class FilesHandler
    {
        private const string k_DataFolderName = "\\monthsFiles";

        public static string GetMonthsFilesPath()
        {
            var path = Directory.GetCurrentDirectory() + k_DataFolderName;
            Directory.CreateDirectory(path);
            return path;
        }

        public static List<FileInfo> GetAllFiles()
        {
            return new List<FileInfo>(new DirectoryInfo(GetMonthsFilesPath()).GetFiles("*"));
        }

        public static string BuildFileName(int i_Year, int i_Month)
        {
            return i_Year + "-" + (i_Month <= 9 ? "0" : "") + i_Month;
        }

        public static string BuildFilePath(int i_Year, int i_Month)
        {
            return GetMonthsFilesPath() + "\\" + BuildFileName(i_Year, i_Month);
        }

        public static List<string> GetFileLines(int i_Year, int i_Month)
        {
            string filePath = BuildFilePath(i_Year, i_Month);

            if (!File.Exists(filePath))
            {
                string[] newFile = createNewMonthArray(i_Year, i_Month);
                File.WriteAllLines(filePath, newFile);
            }

            List<string> fileLines = new List<string>(File.ReadAllLines(filePath, Encoding.UTF8));

            return fileLines;
        }

        public static List<string> GetAllDaysData(int i_Year, int i_Month)
        {
            string filePath = BuildFilePath(i_Year, i_Month);

            if (!File.Exists(filePath))
            {
                string[] newFile = createNewMonthArray(i_Year, i_Month);
                File.WriteAllLines(filePath, newFile);
            }

            List<string> fileLines = new List<string>(File.ReadAllLines(filePath, Encoding.UTF8));

            return fileLines;
        }

        private static string[] createNewMonthArray(int i_Year, int i_Month)
        {
            List<string> newFile = new List<string>();
            for (int i = 1; i <= TimeHandler.DaysInMonth(i_Year, i_Month); i++)
            {
                newFile.Add(string.Format(
                    TimeWatch.ROW_FORMAT,
                    ((i < 10) ? "0" : "") + i,
                    TimeHandler.getWeekDayStr(i_Year, i_Month, i),
                    "",
                    "",
                    "",
                    getDayType(TimeHandler.getWeekDayInt(i_Year, i_Month, i)),
                    "",
                    TimeWatch.sr_RowSeparator));
            }

            return newFile.ToArray();
        }

        private static string getDayType(int i_Day)
        {
            if (i_Day == 5 || i_Day == 6) return DayTypeFactory.Get(eDayType.Holiday);
            return DayTypeFactory.Get(eDayType.WorkDay);
        }

        public static List<string> GetYears()
        {
            List<string> years = new List<string>();
            List<FileInfo> allFiles = GetAllFiles();

            foreach (var file in allFiles)
            {
                string year = getFileYear(file.Name).ToString();
                if (!years.Contains(year))
                {
                    years.Add(year);
                }
            }

            if (!years.Contains(TimeHandler.NextYear().ToString())) years.Add(TimeHandler.NextYear().ToString());

            return years;
        }

        public static int getFileYear(string i_FileName)
        {
            return int.Parse(i_FileName.Split('-')[0]);
        }

        public static int getFileMonth(string i_FileName)
        {
            return int.Parse(i_FileName.Split('-')[1]);
        }
    }
}
