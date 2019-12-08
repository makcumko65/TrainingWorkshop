using System;
using System.Collections.Generic;
using System.Text;
using static Training8.Models.ConsoleCalculator;

namespace Training8.Interface
{
    public interface ICalculator
    {
        double Calculation(double x, double y, Operation operation);
    }
}
