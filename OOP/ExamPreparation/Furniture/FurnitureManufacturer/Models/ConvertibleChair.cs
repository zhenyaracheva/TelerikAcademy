namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair, IChair, IFurniture
    {
        public const decimal ChangeHeight = 0.10m;
        private decimal converted;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.IsConverted = false;
        }

        public bool IsConverted { get; set; }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.Height = this.converted;
            }
            else
            {
                this.converted = this.Height;
                this.Height = ChangeHeight;
            }

            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.Append(string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal"));

            return result.ToString();
        }
    }
}
