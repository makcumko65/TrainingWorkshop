using Structs.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Training3.Interfaces;

namespace Training3.Models
{
    public class FileHelper : IFileHelper
    {
        private readonly IPrinter printer;

        public FileHelper(IPrinter printer)
        {
            this.printer = printer;
        }

        public string GetAllFilesByDirectory(string directory)
        {
            StringBuilder data = new StringBuilder();
            DirectoryInfo dir = new DirectoryInfo($@"{directory}");
            try
            {
                DirectoryInfo[] subDirectories = dir.GetDirectories();
                foreach (var subDir in subDirectories)
                {
                    data.Append($"{subDir}\n");
                    data.Append(GetSubDirectories(subDir));
                }
            }
            catch(DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException();
            }
            return data.ToString();
        }

        private string GetSubDirectories(DirectoryInfo directory)
        {
            StringBuilder data = new StringBuilder();
            foreach (var item in directory.GetDirectories())
            {
                data.Append($"{item} ");
                GetSubDirectories(item);
            }
            return data.ToString();
        }

        public string SearchFileByPartialName(string partialName, string directory)
        {
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo($@"{directory}");
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");
            string fullName = "";

            foreach (FileInfo foundFile in filesInDir)
            {
                fullName = foundFile.FullName;
            }

            return fullName;
        }
    }
}
