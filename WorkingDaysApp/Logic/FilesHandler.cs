using System.Collections.Generic;
using System.IO;
using System.Text;
using WorkingDaysApp.Enums;

namespace WorkingDaysApp.Logic
{
    static class FilesHandler
    {
        public static string GetMonthsFilesPath()
        {
            var path = Path.GetDirectoryName(Directory.GetCurrentDirectory() + "\\monthFiles");
            Directory.CreateDirectory(path);
            return Path.GetDirectoryName(path);
        }

        public static List<FileInfo> GetAllFiles()
        {
            return new List<FileInfo>(new DirectoryInfo(GetMonthsFilesPath()).GetFiles("*"));
        }

        public static string BuildFileName(int Year, int Month)
        {
            return Year + "-" + (Month <= 9 ? "0" : "") + Month + ".txt";
        }

        public static string BuildFilePath(int Year, int Month)
        {
            return GetMonthsFilesPath() + "\\" + BuildFileName(Year, Month);
        }

        public static List<string> GetFileLines(int Year, int Month)
        {
            string filePath = BuildFilePath(Year, Month);

            if (!File.Exists(filePath))
            {
                string[] newFile = createNewMonthArray(Year, Month);
                File.WriteAllLines(filePath, newFile);
            }

            List<string> fileLines = new List<string>(File.ReadAllLines(filePath, Encoding.UTF8));

            return fileLines;
        }

        private static string[] createNewMonthArray(int Year, int Month)
        {
            List<string> newFile = new List<string>();
            for (int i = 1; i <= TimeHandler.DaysInMonth(Year, Month); i++)
            {
                string monthDay = TimeHandler.getWeekDayStr(Year, Month, i);

                newFile.Add(string.Format(
                    WorkingDays.ROW_FORMAT,
                    ((i < 10) ? "0" : "") + i,
                    TimeHandler.getWeekDayStr(Year, Month, i),
                    "",
                    "",
                    "",
                    getDayType(TimeHandler.getWeekDayInt(Year, Month, i)),
                    "",
                    WorkingDays.ROW_SEPARATOR));
            }

            return newFile.ToArray();
        }

        private static string getDayType(int day)
        {
            if (day == 5 || day == 6) return DayTypeFactory.Get(eDayType.DayOff);
            return DayTypeFactory.Get(eDayType.WorkDay);
        }

        public static List<string> GetYears()
        {
            List<string> years = new List<string>();
            List<FileInfo> AllFiles = FilesHandler.GetAllFiles();

            foreach (var file in AllFiles)
            {
                string curYear = file.Name.Split(WorkingDays.ROW_SEPARATOR)[0];
                if (!years.Contains(curYear))
                {
                    years.Add(curYear);
                }
            }
            if (!years.Contains(TimeHandler.NextYear().ToString())) years.Add(TimeHandler.NextYear().ToString());

            return years;
        }
    }
}
