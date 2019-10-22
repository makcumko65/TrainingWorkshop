using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Training3.Interfaces;

namespace Training3.Models
{
    public class FileLogger : ILogger
    {
        public void Save(string way, string data)
        {
            try
            {
                using (var file = new StreamWriter($@"{way}"))
                {
                    file.WriteLine(data);
                }
            }
            catch(DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException();
            }
        }
    }
}
