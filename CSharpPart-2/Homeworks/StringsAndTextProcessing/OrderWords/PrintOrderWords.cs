//Problem 24. Order words

//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Linq;

class PrintOrderWords
{
    static void Main()
    {
        Console.Write("Please, enter a list of words, separate by space: ");
        var words = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().OrderBy(x => x);
        Console.WriteLine(string.Join(", ", words));
    }
}

