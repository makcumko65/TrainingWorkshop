using Structs.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Training5.Interfaces;

namespace Training5.Models
{
    public class Reflection : IReflection
    {
        private readonly IPrinter printer;

        public Reflection(IPrinter printer)
        {
            this.printer = printer;
        }

        public void GetInfoAboutDLL(string assembly)
        {
            Assembly asm = Assembly.LoadFrom(assembly);
            printer.WriteLine($"{asm.FullName}");

            GetModulesAndItsMembers(asm);
        }

        private void GetModulesAndItsMembers(Assembly asm)
        {
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
