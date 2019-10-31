using Structs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Structs.Models
{
    public class ConsolePrinter : IPrinter
    {
        public void ReadLine()
        {
            Console.ReadLine();
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
