namespace TradeCompanyProblem
{
    using System;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    public class Startup
    {
        public static void Main()
        {
            var company = new TradeComapny();

            Stopwatch sw = new Stopwatch();

            Console.WriteLine("OrderedMultiDictionary Tests:");
            sw.Start();
            for (int i = 0; i < 500000; i++)
            {
                company.Add(new Article("Name" + i, "Vendor" + i, "Title" + i, decimal.Parse(i.ToString())));
            }

            sw.Stop();
            Console.WriteLine("Adding 500 000 elements: " + sw.Elapsed);

            sw.Reset();
            sw.Start();

            for (int i = 0; i < 100000; i++)
            {
                company.FindByPraceRange(i, i + 10000);
            }

            sw.Stop();
            Console.WriteLine("Searching 100 000 " + sw.Elapsed);
        }
    }
}
