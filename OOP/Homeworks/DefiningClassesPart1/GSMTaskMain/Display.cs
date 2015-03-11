namespace GSMTaskMain
{
    using System;
    using System.Text;

    public class Display
    {
        private double inches;
        private ConsoleColor? color;

        public Display(double inches, ConsoleColor color)
            : this(inches)
        {
            this.Color = color;
        }

        public Display(double inches)
        {
            this.Inches = inches;
        }

        public double Inches
        {
            get
            {
                return this.inches;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Display inches cannot be smaller than 0!");
                }

                this.inches = value;
            }
        }

        public ConsoleColor? Color
        {
            get
            {
                return this.color;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Display color cannot be null!");
                }

                this.color = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("- Display inches: {0}", this.Inches));

            if (this.Color != null)
            {
                result.AppendLine(string.Format("- Display color: {0}", this.Color));
            }

            return result.ToString().Trim();
        }
    }
}
