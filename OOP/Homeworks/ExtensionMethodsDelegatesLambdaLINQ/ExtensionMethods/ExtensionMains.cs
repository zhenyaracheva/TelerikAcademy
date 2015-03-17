namespace ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExtensionMains
    {
        public static void Main()
        {
            var str = new StringBuilder("Pesho");
            var result = str.Substring(2, 3);
            Console.WriteLine("Test substring:");
            Console.WriteLine(result);
            Console.WriteLine("Collection values: 25, 10, 5");

            var list = new List<int>();
            list.Add(10);
            list.Add(15);
            list.Add(5);
            Console.WriteLine("Test sum method:");
            Console.WriteLine(list.Sum());
            Console.WriteLine("Test product method:");
            Console.WriteLine(list.Product());
            Console.WriteLine("Test min method:");
            Console.WriteLine(list.Min());
            Console.WriteLine("Test max method:");
            Console.WriteLine(list.Max());
            Console.WriteLine("Test average method:");
            Console.WriteLine(list.Average());
        }
    }
}
