using Structs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Training8.Interface;

namespace Training8.Models
{
    public class ConsoleCalculator : ICalculator
    {
        private readonly IPrinter printer;

        public ConsoleCalculator(IPrinter printer)
        {
            this.printer = printer;
        }

        public double Calculation(double x, double y, char operation)
        {
            if (operation == '*')
                return x * y;
            else if (operation == '+')
                return x + y;
            else if (operation == '/')
            {
                try
                {
                    return x / y;
                }
                catch (DivideByZeroException)
                {
                    throw new DivideByZeroException();
                }
            }
            else if (operation == '-')
                return x - y;
            printer.WriteLine("WrongData");
            throw new InvalidCastException();
        }
    }
}
