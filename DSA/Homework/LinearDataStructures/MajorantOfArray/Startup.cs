namespace MajorantOfArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var test = new List<int>() { 2, 3, 3, 2, 3, 4, 3, 3 };
            var majorants = test.Where(n => (test.Count(s => s == n) >= ((test.Count / 2) + 1)));
            var result = majorants.Count() > 0 ? majorants.Max().ToString() : "No majorants!";
            Console.WriteLine(result);
        }
    }
}
