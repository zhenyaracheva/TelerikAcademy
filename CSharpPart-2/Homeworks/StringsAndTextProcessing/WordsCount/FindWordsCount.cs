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
        Dictionary<string, int> dict = new Dictionary<string, int>();

        var matches = Regex.Matches(text, @"\b\w+\b");

        foreach (var word in matches)
        {
            if (dict.Keys.Contains(word))
            {
                
            }
        }

    }
}

