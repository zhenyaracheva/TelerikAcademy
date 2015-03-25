namespace Shapes
{
    using Shapes.Interfaces;

    public class Square : Shape, IShape
    {
        public Square(decimal width)
            : base(width, width)
        {
        }

        public override decimal CalculateSurface()
        {
            return this.Width * this.Width;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("; Area: {0:F2}", this.CalculateSurface());
        }
    }
}
