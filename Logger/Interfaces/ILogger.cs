using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Interfaces
{
    public interface ILogger
    {
        void ReadMessage();
        void WriteMessage(string logLevel,string data);
        void Error(Exception exception, string message);
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Fatal(string message);

    }
}
