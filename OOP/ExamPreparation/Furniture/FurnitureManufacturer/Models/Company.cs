namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string initialName, string initialRegistrationNumber)
        {
            this.Name = initialName;
            this.RegistrationNumber = initialRegistrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company name cannot be null or empty!");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Company name cannot be shorter than 5 symbols!");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Company registration number must be 10 symbols!");
                }

                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new ArgumentException("Company name must contains only digits!");
                    }
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }

            private set
            {
                this.furnitures = new List<IFurniture>();
            }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("Added furniture cannot be null!");
            }

            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("Removed furniture cannot be null!");
            }

            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            foreach (var furniture in this.Furnitures)
            {
                if (furniture.Model.ToLower() == model.ToLower())
                {
                    return furniture;
                }
            }

            return null;
        }

        public string Catalog()
        {
            var result = new StringBuilder();

            string furnitureCount = this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no";
            string furnituresVsFurniture = this.Furnitures.Count != 1 ? "furnitures" : "furniture";
            result.AppendLine(string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber, furnitureCount, furnituresVsFurniture));

            if (this.Furnitures.Count > 0)
            {
                var sorted = this.Furnitures
                            .OrderBy(f => f.Price)
                            .ThenBy(f => f.Model);
                foreach (var sorfFurniture in sorted)
                {
                    result.AppendLine(sorfFurniture.ToString());
                }
            }

            return result.ToString().Trim();
        }
    }
}
