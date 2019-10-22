using System;
using System.Collections.Generic;
using System.Text;

namespace Structs
{
    public interface ISize
    {
        double Width { get; set; }
        double Height { get; set; }

        double Perimetr();
    }
}
