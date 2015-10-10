namespace VariablesDataExpressionsConstant
{
    using System;

    public class Size
    {
        private double width;
        private double heigth;

        public Size(double w, double h)
        {
            this.width = w;
            this.heigth = h;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Size width cannot be negative number!");
                }

                this.width = value;
            }
        }

        public double Heigth
        {
            get
            {
                return this.heigth;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Size heigth cannot be negative number!");
                }

                this.heigth = value;
            }
        }

        public static Size GetRotatedSize(Size size, double angle)
        {
            var width = RotateWidth(size, angle);
            var heigth = RotateHeigth(size, angle);

            return new Size(width, heigth);
        }

        private static double RotateWidth(Size size, double angle)
        {
            return (Math.Abs(Math.Sin(angle)) * size.heigth) + (Math.Abs(Math.Cos(angle)) * size.width);
        }

        private static double RotateHeigth(Size size, double angle)
        {
            return (Math.Abs(Math.Sin(angle)) * size.width) + (Math.Abs(Math.Cos(angle)) * size.heigth);
        }
    }
}
