//Problem 22. Words count

//Write a program that reads a string from the console and lists all different words in the string 
//along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class FindWordsCount
{
    static void Main()
    {
        Console.Write("Please,enter text: ");
        string text = Console.ReadLine();
        var dict = new SortedDictionary<string, int>();

        var words = Regex.Matches(text, @"\b\w+\b");

        foreach (var word in words)
        {
            if (dict.Keys.Contains(word.ToString()))
            {
                dict[word.ToString()] += 1;
            }
            else
            {
                dict[word.ToString()] = 1;
            }
        }

        foreach (var word in dict)
        {
            Console.WriteLine("{0}- {1}", word.Key, word.Value);
        }

    }
}

