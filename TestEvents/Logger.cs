using System;
using System.Collections.Generic;
using System.IO;

namespace TestEvents
{
    class Logger
    {

        static string path
        {
            get
            {
                return System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonDocuments) + "\\ScanerLogs\\";
            }
        }

        string LoggerFileNameNow
        {
            get
            {
                return path + "Logger_for_FingerprintScanner.txt";
            }
        }

        public void CreateLoggerFile(string WhatHappened)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!this.FileExist())
                {
                using (FileStream fs = File.Create(LoggerFileNameNow)) ;
                }
            using (StreamWriter file = new StreamWriter(LoggerFileNameNow, true))
            {
                file.WriteLine("{0} - {1}", DateTime.Now.ToString("yyyy-MM-d HH:mm:ss"), WhatHappened);
            }
        }

        bool FileExist()
        {
            if (File.Exists(LoggerFileNameNow))
                return true;
            else
                return false;
        }

    }
}
