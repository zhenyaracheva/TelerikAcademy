namespace RecoverMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var words = new string[n];
            var maxLenght = 0;

            for (int i = 0; i < n; i++)
            {
                words[i] = Console.ReadLine();

                if (maxLenght < words[i].Length)
                {
                    maxLenght = words[i].Length;
                }
            }

            var output = new StringBuilder();

            for (int i = 0; i < maxLenght; i++)
            {
                var letters = new SortedSet<char>();
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].Length > i && !output.ToString().Contains(words[j][i]))
                    {
                        letters.Add(words[j][i]);
                    }
                }

                output.Append(string.Join("", letters));
            }

            Console.WriteLine(output);
        }
    }
}
