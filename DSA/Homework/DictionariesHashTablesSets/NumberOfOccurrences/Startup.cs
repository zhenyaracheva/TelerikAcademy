namespace NumberOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(double.Parse)
                                            .ToList();

            var occurrences = GetOccurrences(numbers);
            PrintResult(occurrences);
        }

        private static IDictionary<double, int> GetOccurrences(IList<double> numbers)
        {
            var occurrences = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!occurrences.ContainsKey(number))
                {
                    occurrences[number] = 0;
                }

                occurrences[number]++;
            }

            return occurrences;
        }

        private static void PrintResult(IDictionary<double, int> occurrences)
        {
            foreach (var number in occurrences)
            {
                Console.WriteLine("{0} -> {1} times", number.Key, number.Value);
            }
        }
    }
}
