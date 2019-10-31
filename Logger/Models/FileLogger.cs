using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Logger.Models
{
    public class FileLogger : ILogger
    {
        public string Way { get; set; }
        
        public FileLogger()
        {
            Way = ConfigurationManager.AppSettings.Get("UrlToPing");
        }
        public void ReadMessage()
        {
            throw new NotImplementedException();
        }

        public void WriteMessage(string logLevel, string message)
        {
            using (var file = new StreamWriter($@"{Way}",true))
            {
              file.WriteLine($"{DateTime.Now} || {logLevel} || {message}");
            }
        }

        public void Error(Exception exception, string message)
        {
            using (var file = new StreamWriter($@"{Way}", true))
            {
                file.WriteLine($"{DateTime.Now} || ERROR || {message} || {exception.Message}");
            }
        }

        public void Debug(string message)
        {
            WriteMessage("DEBUG", message);
        }

        public void Info(string message)
        {
            WriteMessage("INFO", message);
        }

        public void Warn(string message)
        {
            WriteMessage("WARN", message);
        }

        public void Fatal(string message)
        {
            WriteMessage("FATAL", message);
        }
    }
}
