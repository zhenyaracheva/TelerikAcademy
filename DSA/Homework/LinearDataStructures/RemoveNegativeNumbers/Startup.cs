namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.Write("Test more than one positive and negative numbers: ");
            var test1 = GetAllNonNegativeNumbers(new List<int>() { 1, 5, -9, 5, -8, 0, -1, 3, -6, 7 });
            Console.WriteLine(string.Join(", ", test1));

            Console.Write("Test only one positive numbers: ");
            var test2 = GetAllNonNegativeNumbers(new List<int>() { -1, -5, -9, -5, -8, -1, -3, -6, 7 });
            Console.WriteLine(string.Join(", ", test2));

            Console.Write("Test only negative numbers: ");
            var test3 = GetAllNonNegativeNumbers(new List<int>() { -1, -5, -9, -5, -8, -1, -3, -6, -7 });
            Console.WriteLine(string.Join(", ", test3));
        }

        public static List<int> GetAllNonNegativeNumbers(IList<int> numbers)
        {
            return numbers.Where(n => n >= 0).ToList();
        }
    }
}
