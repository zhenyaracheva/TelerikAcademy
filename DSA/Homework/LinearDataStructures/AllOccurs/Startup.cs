namespace AllOccurs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2, 4 };

            numbers.GroupBy(n => n)
                 .ToList()
                 .ForEach(x => Console.WriteLine("{0} -> {1}", x.Key, x.Count()));
        }
    }
}
