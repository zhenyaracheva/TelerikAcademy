namespace Abstraction
{
    using System;

    using Abstraction.Interfaces;

    public abstract class Figure : IFigure
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        protected void ValidateEqualOrLessThanZero(double value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentException(name + " cannot be less or equal to 0!");
            }
        }
    }
}
