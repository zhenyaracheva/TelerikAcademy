namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, ITable, IFurniture
    {
        private decimal lenght;
        private decimal width;
        private decimal area;

        public Table(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
            this.Area = this.Length * this.Width;
        }

        public decimal Length
        {
            get
            {
                return this.lenght;
            }

            private set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentException("Table lenght cannot be smaller or equal to 0!");
                }

                this.lenght = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Table width cannot be smaller or equal to 0!");
                }

                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.area;
            }

            private set
            {
                this.area = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendLine(string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area));

            return result.ToString().Trim();
        }
    }
}
