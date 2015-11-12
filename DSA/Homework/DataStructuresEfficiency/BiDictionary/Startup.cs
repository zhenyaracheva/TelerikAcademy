namespace BiDictionary
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var dictionary = new BiDictionary<int, string, string>(true);

            dictionary.Add(1, "Stolichansko", "Duplicate");
            dictionary.Add(1, "Stolichansko", "Duplicate");
            dictionary.Add(1, "Hariana", "Stolichansko");

            dictionary.Add(2, "Hariana", "Hmel");
            dictionary.Add(2, "Hariana-2", "Double Hmel");

            Console.WriteLine(string.Join(", ", dictionary.GetByFirstKey(1)));
            Console.WriteLine(string.Join(", ", dictionary.GetBySecondKey("Hariana")));
            Console.WriteLine(string.Join(", ", dictionary.GetByTwoKeys(1, "Stolichansko")));

            PrintAllValues(dictionary);

            dictionary.RemoveByFirstKey(4);

            PrintAllValues(dictionary);

            dictionary.RemoveBySecondKey("Hariana");

            PrintAllValues(dictionary);

            dictionary.RemoveByTwoKeys(1, "Stolichansko");

            PrintAllValues(dictionary);
            dictionary.Clear();

            PrintAllValues(dictionary);
        }

        public static void PrintAllValues<K1, K2, V>(BiDictionary<K1, K2, V> dictionary)
        {
            Console.WriteLine();
            Console.WriteLine("Count: " + dictionary.Count);

            foreach (var value in dictionary.Values)
            {
                Console.WriteLine("Key1: " + value.Key1 + "; Key2: " + value.Key2 + "; Value: " + value.Value);
            }
        }
    }
}
