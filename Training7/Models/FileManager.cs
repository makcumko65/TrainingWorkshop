using Structs.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Training7.Models
{
    public class FileManager
    {
        private readonly IPrinter printer;

        public FileManager(IPrinter printer)
        {
            this.printer = printer;
        }

        public void GetDublicateFilesInTwoFolders(string assembly1, string assembly2)
        {
        }

        public void GetDublicateFilesInFolder(string folder)
        {
            Assembly asm = Assembly.LoadFrom(folder);
            printer.WriteLine($"{asm.FullName}");

            Type[] types = asm.GetTypes();
            //foreach (Module md in asm.GetModules(true))
            //{
            //    printer.WriteLine(md.ToString());
            //}
            foreach (Type type in types)
            {
                printer.WriteLine(type.Name);
                foreach (MemberInfo m in type.GetMembers())
                {
                    printer.WriteLine($"\t {m.ToString()}");
                }
            }
        }
    }
}
