namespace OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var result = new StringBuilder();
            var input = Console.ReadLine();

            var productsByName = new HashSet<string>();
            var productsByType = new Dictionary<string, List<Product>>();
            var productsByPrice = new SortedDictionary<double, List<Product>>();

            while (true)
            {
                if (input.StartsWith("add"))
                {
                    var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = command[1];
                    var type = command[3];
                    var price = double.Parse(command[2]);

                    var product = new Product(name, type, price);

                    if (!productsByName.Contains(name))
                    {
                        productsByName.Add(name);
                        result.AppendLine(string.Format("Ok: Product {0} added successfully", name));
                    }
                    else
                    {
                        result.AppendLine(string.Format("Error: Product {0} already exists", name));
                        input = Console.ReadLine();
                        continue;
                    }

                    if (!productsByType.ContainsKey(type))
                    {
                        productsByType.Add(type, new List<Product>());
                    }

                    productsByType[type].Add(product);

                    if (!productsByPrice.ContainsKey(price))
                    {
                        productsByPrice.Add(price, new List<Product>());
                    }

                    productsByPrice[price].Add(product);
                }
                else if (input.StartsWith("filter by type"))
                {
                    var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var type = command[3];

                    if (productsByType.ContainsKey(type))
                    {
                        GetFirstProducts(productsByType[type], result);
                    }
                    else
                    {
                        result.AppendLine(string.Format("Error: Type {0} does not exists", type));
                    }
                }
                else if (input.StartsWith("filter by price from") && input.Contains("to"))
                {
                    var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var minPrice = double.Parse(command[4]);
                    var maxPrice = double.Parse(command[6]);

                    var res = productsByPrice.Where(x => (x.Key >= minPrice && x.Key <= maxPrice))
                                                    .SelectMany(x => x.Value)
                                                    .ToList();

                    GetFirstProducts(res, result);

                }
                else if (input.StartsWith("filter by price from"))
                {
                    var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var minPrice = double.Parse(command[4]);

                    var res = productsByPrice.Where(x => (x.Key >= minPrice))
                                                    .SelectMany(x => x.Value)
                                                    .ToList();

                    GetFirstProducts(res, result);
                }
                else if (input.StartsWith("filter by price to"))
                {
                    var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var maxPrice = double.Parse(command[4]);

                    var res = productsByPrice.Where(x => (x.Key <= maxPrice))
                                                    .SelectMany(x => x.Value)
                                                    .ToList();

                    GetFirstProducts(res, result);
                }
                else if (input == "end")
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static void GetFirstProducts(List<Product> list, StringBuilder result)
        {
            var res = list.OrderBy(x => x.Price)
                          .ThenBy(x => x.Name)
                          .ThenBy(x => x.Type)
                          .Take(10);

            result.AppendLine("Ok: " + string.Join(", ", res));
        }
    }

    public class Product 
    {
        public Product(string name, string type, double price)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return this.Name + "(" + this.Price + ")";
        }
    }
}
