using System;
using System.Collections.Generic;
using System.IO;

namespace SoundBoard.Persistence
{
    public static class Logger
    {
        private static readonly string logFileName = "logFile_" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        private static readonly string logsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SoundBoard\\Logs\\");

        public static void NewLog(Exception ex, string message = "None.")
        {
            DateTime date = DateTime.Now;
            using (System.IO.StreamWriter file = File.AppendText(logsFolderPath + logFileName + ".txt"))
            {
                file.WriteLine(new Log(date, message, ex.Message, ex.StackTrace).ToString());
            }
        }

        public static string LogsFolderPath
        {
            get { return logsFolderPath; }
        }

        internal class Log
        {
            private DateTime timeStamp;
            private string message;
            private string exceptionMessage;
            private string stackTrace;

            public Log(DateTime timeStamp, string message, string exceptionMessage, string stackTrace)
            {
                this.timeStamp = timeStamp;
                this.message = message;
                this.exceptionMessage = exceptionMessage;
                this.stackTrace = stackTrace;
            }

            public override string ToString()
            {
                string result = "";
                result += "[" + this.timeStamp.ToString("yyyy-MM-dd HH:mm:ss") + "]";
                result += " Error message : " + this.message + Environment.NewLine;
                result += "Exception message : " + this.exceptionMessage + Environment.NewLine;
                result += "Stacktrace : " + this.stackTrace;
                return result;
            }
        }
    }
}
