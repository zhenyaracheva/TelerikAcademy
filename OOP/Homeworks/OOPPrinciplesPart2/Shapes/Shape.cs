namespace Shapes
{
    using System;

    using Shapes.Interfaces;

    public abstract class Shape : IShape
    {
        private decimal width;
        private decimal height;

        public Shape(decimal initialWidth, decimal initialHeight)
        {
            this.Width = initialWidth;
            this.Height = initialHeight;
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be less or equal to 0.");
                }

                this.width = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be less or equal to 0.");
                }

                this.height = value;
            }
        }

        public abstract decimal CalculateSurface();

        public override string ToString()
        {
            return string.Format("{0,-10}: [Width: {1:F2}, Height: {2:F2}]", this.GetType().Name, this.Width, this.Height);
        }
    }
}
