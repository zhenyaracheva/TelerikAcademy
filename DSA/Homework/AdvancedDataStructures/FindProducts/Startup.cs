namespace FindProducts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Startup
    {
        public static void Main()
        {
            var products = new Bag<Product>();
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Bag Tests:");
            sw.Start();
            for (int i = 0; i < 500000; i++)
            {
                products.Add(new Product("Name" + i, i));
            }

            sw.Stop();
            Console.WriteLine("Adding 500 000 elements: " + sw.Elapsed);

            sw.Reset();
            sw.Start();

            for (int i = 0; i < 100000; i++)
            {
                FindProductsByPrice(i, i + 10000, products);
            }

            sw.Stop();
            Console.WriteLine("Searching 100 000 " + sw.Elapsed);

            Console.WriteLine("OrderedBag Tests:");
            var orderedProducts = new OrderedBag<Product>();
            sw.Reset();
            sw.Start();
            for (int i = 0; i < 500000; i++)
            {
                orderedProducts.Add(new Product("Name" + i, i));
            }

            sw.Stop();
            Console.WriteLine("Adding 500 000 elements: " + sw.Elapsed);

            sw.Reset();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                FindProductsByPrice(i, i + 10000, orderedProducts);
            }

            sw.Stop();
            Console.WriteLine("Searching 100 000 " + sw.Elapsed);
        }

        private static IEnumerable<Product> FindProductsByPrice(decimal startPrice, decimal endPrice, Bag<Product> products)
        {
            return products.Where(x => x.Price >= startPrice && x.Price <= endPrice)
                           .OrderBy(x => x)
                           .Take(20);
        }

        private static IEnumerable<Product> FindProductsByPrice(decimal startPrice, decimal endPrice, OrderedBag<Product> products)
        {
            return products.Where(x => x.Price >= startPrice && x.Price <= endPrice)
                           .OrderBy(x => x)
                           .Take(20);
        }
    }
}
