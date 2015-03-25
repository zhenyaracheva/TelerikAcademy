namespace Shapes
{
    using System;

    using Shapes.Interfaces;

    public class Triangle : Shape, IShape
    {
        public Triangle(decimal width, decimal height)
            : base(width, height)
        {
        }

        public override decimal CalculateSurface()
        {
            return (this.Width * this.Height) / 2;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("; Area: {0:F2}", this.CalculateSurface());
        }
    }
}
