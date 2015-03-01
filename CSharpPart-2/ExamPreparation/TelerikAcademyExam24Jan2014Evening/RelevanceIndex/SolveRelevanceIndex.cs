using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class SolveRelevanceIndex
{
    static void Main()
    {
        string matchWord = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        SortedDictionary<int, string> dict = new SortedDictionary<int, string>();

        for (int i = 0; i < n; i++)
        {
            string[] paragraph = Console.ReadLine().Split(new char[] { '.', ',', '?', '!', '-', '(', ')', ' ', ';' }, 
                StringSplitOptions.RemoveEmptyEntries);

            int counter = 0;

            for (int j = 0; j < paragraph.Length; j++)
            {
                if (paragraph[j].ToLower() == matchWord.ToLower())
                {
                    paragraph[j] = paragraph[j].ToUpper();
                    counter++;
                }
            }

            dict[counter] = string.Join(" ", paragraph);
        }

        foreach (var paragraph in dict.Reverse())
        {
            Console.WriteLine(paragraph.Value);
        }
    }

}
