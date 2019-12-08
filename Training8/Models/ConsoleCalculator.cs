  using Structs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Training8.Interface;

namespace Training8.Models
{
    public class ConsoleCalculator : ICalculator
    {
        public delegate double Operation(double x, double y);
        private readonly IPrinter printer;

        public ConsoleCalculator(IPrinter printer)
        {
            this.printer = printer;
        }

        public double Calculation(double x, double y, Operation operation)
        {
            return operation(x, y);
        }
        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
