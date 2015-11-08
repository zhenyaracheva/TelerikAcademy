namespace FindProducts
{
    using System;

    public class Product : IComparable
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            var product = obj as Product;

            if (this.Name == product.Name && this.Price == product.Price)
            {
                return 0;
            }
            else if (this.Price < product.Price)
            {
                return 1;
            }

            return -1;
        }
    }
}
