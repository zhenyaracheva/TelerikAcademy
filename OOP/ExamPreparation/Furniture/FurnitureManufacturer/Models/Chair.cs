namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public class Chair : Furniture, IChair, IFurniture
    {
        private int numberOfLegs;

        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Chair cannot have 0 or less number of legs!");
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendLine(string.Format(", Legs: {0}", this.NumberOfLegs));

            return result.ToString().Trim();
        }
    }
}
