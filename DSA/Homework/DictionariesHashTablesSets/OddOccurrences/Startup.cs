namespace OddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           .ToList();

            var oddOccurrences = GetOddOccurrences(words);
            PrintOccurrences(oddOccurrences);
        }

        private static void PrintOccurrences(IDictionary<string, int> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine("{0} -> {1} times", word.Key, word.Value);
            }
        }

        private static IDictionary<string, int> GetOddOccurrences(IList<string> words)
        {
            var occurrences = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!occurrences.ContainsKey(word))
                {
                    occurrences[word] = 0;
                }

                occurrences[word]++;
            }

            var oddOccurrences = new SortedDictionary<string, int>();

            foreach (var word in occurrences)
            {
                if (word.Value % 2 == 1)
                {
                    oddOccurrences[word.Key] = word.Value;
                }
            }

            return oddOccurrences;
        }
    }
}
