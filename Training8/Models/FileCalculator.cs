using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Training8.Interface;

namespace Training8.Models
{
    public class FileCalculator : ICalculator
    {
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
            return 0.0;
        }
    }
}
