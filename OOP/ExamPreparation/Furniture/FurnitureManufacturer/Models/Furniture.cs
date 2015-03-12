namespace FurnitureManufacturer.Models
{
    using System;
    using System.Linq;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string initialModel, string initialMaterial, decimal currerntPrice, decimal initialHeight)
        {
            this.Model = initialModel;
            this.Material = initialMaterial;
            this.Price = currerntPrice;
            this.Height = initialHeight;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Furniture model cannot be null or empty!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Furniture model cannot be shorter than 3 symbols!");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Furniture matirial cannot be null!");
                }

                this.material = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Furniture price cannot be smaller or equal to 0!");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Furniture height cannot be smaller or equal to 0!");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            string type = this.GetType().Name;
            string modelAsString = this.Model;
            string materialAsString = this.Material.First().ToString().ToUpper() + this.Material.Substring(1);
            string priceAsString = this.Price.ToString();
            string heightAsString = this.Height.ToString();
            result.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3:F2}, Height: {4:F2}", type, modelAsString, materialAsString, priceAsString, heightAsString));

            return result.ToString();
        }
    }
}
