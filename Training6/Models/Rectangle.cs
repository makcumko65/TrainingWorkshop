using Training6.Interfaces;

namespace Training6.Models
{
    public class Rectangle : IRectangle
    {
        private readonly Point a;
        private readonly Point c;

        public double Height { get; set; }
        public double Width { get; set; }

        public Rectangle() { }
        public Rectangle(Point a,Point c)
        {
            this.a = a ?? throw new System.ArgumentNullException(nameof(a));
            this.c = c ?? throw new System.ArgumentNullException(nameof(c));
            Height = a.Y - c.Y;
        }

        public void MoveRectangle(double changeX, double changeY)
        {
            this.a.MovePoint(changeX, changeY);
            this.c.MovePoint(changeX, changeY);
        }

        public Rectangle TheSmallestRectangleFromTwoRectangles(Rectangle rectangle)
        {
            Rectangle theSmallestRectangle = new Rectangle();
            if(this.a.X < rectangle.a.X)
            {
                theSmallestRectangle.a.X = this.a.X;
                if(this.a.Y > rectangle.a.Y)
                {
                    theSmallestRectangle.a.Y = this.a.Y;
                }
                else
                {
                    theSmallestRectangle.a.Y = rectangle.a.Y;
                }
            }
            return this;
        }
    }
}
