﻿using System;
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
            return GetMonthsFilesPath() + "\\" + BuildFileName(Year, Month);
        }

        public static List<string> GetFileLines(int Year, int Month)
        {
            string filePath = BuildFilePath(Year, Month);

            if (!File.Exists(filePath))
            {
                File.WriteAllLines(filePath, new[] { "" });
            }

            List<string> fileLines = new List<string>(File.ReadAllLines(filePath, Encoding.UTF8));

            return fileLines;
        }
    }
}
