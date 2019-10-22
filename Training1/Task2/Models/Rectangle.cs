using System;
using System.Collections.Generic;
using System.Text;

namespace Structs
{
    public struct Rectangle : ICoordinates, ISize
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double X, double Y, double Width, double Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        public double Perimetr()
        {
            if (Width > 0 && Height > 0)
                return 2 * (Width + Height);
            throw new Exception("Width and Height must be > 0");
        }
    }
}
