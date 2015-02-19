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
        string text = Console.ReadLine();
        HashSet<char> chars = new HashSet<char>();

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                chars.Add(text[i]);
            }
        }

        Console.WriteLine(string.Join(", ", chars.OrderBy(x => x)));
    }
}

