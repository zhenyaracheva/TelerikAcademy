//Problem 21. Letters count

//Write a program that reads a string from the console and prints all different letters 
//in the string along with information how many times each letter is found.

using System;
using System.Collections.Generic;
using System.Linq;

class PrintLettersCount
{
    static void Main()
    {
        Console.Write("Please, enter text: ");
        string text = Console.ReadLine().ToLower();
        var dict = new SortedDictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            char currentLetter = text[i];
            if (char.IsLetter(currentLetter))
            {
                if (dict.ContainsKey(currentLetter))
                {
                    dict[currentLetter]++;
                }
                else
                {
                    dict.Add(currentLetter, 1);
                }
            }
        }


        foreach (var item in dict)
        {
            Console.WriteLine("{0}- {1}", item.Key, item.Value);
        }

    }
}

