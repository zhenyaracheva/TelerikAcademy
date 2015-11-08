namespace WordsFormFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> words = File.ReadAllText("../../words.txt")
                                     .Split(new[] { ' ', ',', '.', '!', '?', '-', '\"', '(', ')', '[', ']', '\\', '/', '\r', '\n', '�' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(x => x.ToLower())
                                     .ToList();

            var wordOccurrences = new SortedDictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordOccurrences.ContainsKey(word))
                {
                    wordOccurrences[word] = 0;
                }

                wordOccurrences[word]++;
            }

            var orderByOccurrence = wordOccurrences.OrderBy(x => x.Value);

            foreach (var word in orderByOccurrence)
            {
                Console.WriteLine("{0} -> {1} times", word.Key, word.Value);
            }
        }
    }
}
