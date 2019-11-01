using Structs.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Training7.Models
{
    public class FileManager
    {
        private readonly IPrinter printer;

        public static int Count;

        public FileManager(IPrinter printer)
        {
            this.printer = printer;
        }

        public HashSet<string> GetDublicateFilesInTwoFolders(string assembly1, string assembly2)
        {
            var dictionary1 = GetDublicateFilesInFolder(assembly1);
            var dictionary2 = GetDublicateFilesInFolder(assembly2);

            var list1 = dictionary1.Where(x => (x.Value == 2) || (dictionary2.ContainsKey(x.Key)))
                .Select(k => k.Key).ToList();
            var list2 = dictionary2.Where(x => (x.Value == 2) || (dictionary1.ContainsKey(x.Key)))
                .Select(k => k.Key).ToList();

            HashSet<string> uniqueSet = list1.Union(list2).ToHashSet();

            return uniqueSet;
        }

        public HashSet<string> GetUniqueFilesInTwoFolders(string assembly1, string assembly2)
        {
            var dictionary1 = GetDublicateFilesInFolder(assembly1);
            var dictionary2 = GetDublicateFilesInFolder(assembly2);

            var list1 = dictionary1.Where(x => (x.Value == 1) || (!dictionary2.ContainsKey(x.Key)))
                .Select(k => k.Key).ToList();
            var list2 = dictionary2.Where(x => (x.Value == 1) || (!dictionary1.ContainsKey(x.Key)))
                .Select(k => k.Key).ToList();

            HashSet<string> uniqueSet = list1.Union(list2).ToHashSet();

            return uniqueSet;
        }

        public Dictionary<string, int> GetDublicateFilesInFolder(string directory)
        {
            DirectoryInfo dir = new DirectoryInfo($@"{directory}");
            Dictionary<string,int> dictionary = new Dictionary<string, int>();
            try
            {
                DirectoryInfo[] subDirectories = dir.GetDirectories();
                foreach (var subDir in subDirectories)
                {
                    foreach (var file in subDir.GetFiles())
                    {
                        if (!dictionary.ContainsKey(file.Name.ToString()))
                        {
                            dictionary.Add(file.Name.ToString(), 1);
                        }
                        else
                        {
                            dictionary[file.Name.ToString()] += 1;
                        }
                    }
                    //printer.WriteLine($"{subDir}\n");
                    GetSubDirectories(subDir,dictionary);
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException();
            }
            catch(Exception)
            {
                throw new Exception();
            }
            return dictionary;
        }

        private Dictionary<string,int> GetSubDirectories(DirectoryInfo directory, Dictionary<string, int> dictionary)
        {
            foreach (var item in directory.GetDirectories())
            {
                foreach (var file in item.GetFiles())
                {
                    if (!dictionary.ContainsKey(file.Name.ToString()))
                    {
                        dictionary.Add(file.Name.ToString(), 1);
                    }
                    else
                    {
                        dictionary[file.Name.ToString()] += 1;
                    }
                }
                GetSubDirectories(item, dictionary);
            }
            return dictionary;
        }
    }
}
