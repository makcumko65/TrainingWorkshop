using Training6.Interfaces;

namespace Training6.Models
{
    public class Point : IPoint
    {
        public double X { get; set; }
        public double Y { get; set; }        
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public void MovePoint(double xChange, double yChange)
        {
            this.X += xChange;
            this.Y += yChange;
        }
    }
}
