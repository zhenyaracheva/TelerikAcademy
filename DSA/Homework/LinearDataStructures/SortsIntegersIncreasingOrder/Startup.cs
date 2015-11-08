namespace SortsIntegersIncreasingOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = GetIntegersFromUser();
            numbers.Sort();
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static List<int> GetIntegersFromUser()
        {
            var numbers = Console.ReadLine().Split(new[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(num => int.Parse(num))
                                            .ToList();
            return numbers;
        }
    }
}
