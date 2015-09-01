using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WorkingDaysApp.Logic
{
    static class FilesHandler
    {
        public static string GetMonthsFilesPath()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\monthFiles";
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
            return FilesHandler.GetMonthsFilesPath() + "\\" + BuildFileName(Year, Month);
        }

    }
}
