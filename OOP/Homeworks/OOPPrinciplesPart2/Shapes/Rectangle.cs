namespace Shapes
{
    using Shapes.Interfaces;

    public class Rectangle : Shape, IShape
    {
        public Rectangle(decimal width, decimal height)
            : base(width, height)
        {
        }

        public override decimal CalculateSurface()
        {
            return this.Width * this.Height;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("; Area: {0:F2}", this.CalculateSurface());
        }
    }
}
