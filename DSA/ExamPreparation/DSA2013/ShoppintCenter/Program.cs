namespace Problem5___ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = new StringBuilder();
            var dictByName = new Dictionary<string, Bag<Product>>();
            var dictByPrice = new Dictionary<double, Bag<Product>>();
            var dictByProducer = new Dictionary<string, Bag<Product>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var command = line.Substring(0, line.IndexOf(' '));
                var commandParams = line.Substring(line.IndexOf(' ')).Split(';');

                if (command == "AddProduct")
                {
                    var productName = commandParams[0];
                    var price = double.Parse(commandParams[1]);
                    var producer = commandParams[2];

                    var product = new Product(productName, price, producer);

                    if (!dictByName.ContainsKey(productName))
                    {
                        dictByName.Add(productName, new Bag<Product>());
                    }

                    if (!dictByProducer.ContainsKey(producer))
                    {
                        dictByProducer.Add(producer, new Bag<Product>());
                    }

                    if (!dictByPrice.ContainsKey(price))
                    {
                        dictByPrice.Add(price, new Bag<Product>());
                    }

                    dictByName[productName].Add(product);
                    dictByProducer[producer].Add(product);
                    dictByPrice[price].Add(product);

                    result.AppendLine("Product added");

                }
                else if (command == "DeleteProducts")
                {
                    if (commandParams.Length == 1)
                    {

                    }
                    else
                    {
                        var producer = commandParams[0];

                        if (!dictByProducer.ContainsKey(producer) || dictByProducer[producer].Count == 0)
                        {
                            result.AppendLine("No products found");
                        }

                        var deleted = dictByProducer[producer].Count;
                        dictByProducer[producer] = new Bag<Product>();

                        var res = dictByName.SelectMany(x => x.Value)
                                            .Where(x => x.Producer == producer)
                                            .ToList();

                    }
                }
                else if (command == "FindProductsByName")
                {

                }
                else if (command == "FindProductsByPriceRange")
                {

                }
                else if (command == "FindProductsByProducer")
                {

                }
            }

            Console.WriteLine(result.ToString());
        }
    }

    public class Product
    {
        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; private set; }

        public double Price { get; private set; }

        public string Producer { get; private set; }
    }
}