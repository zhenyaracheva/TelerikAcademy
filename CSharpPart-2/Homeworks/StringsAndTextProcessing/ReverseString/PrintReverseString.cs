//Problem 2. Reverse string

//Write a program that reads a string, reverses it and prints the result at the console.
//Example:

//input	    output
//sample	elpmas

using System;
using System.Linq;

class PrintReverseString
{
    static void Main()
    {
        Console.Write("Please,enter a word: ");
        string word = Console.ReadLine();
        Console.Write("Reversed: ");
        Console.WriteLine(string.Concat(Enumerable.Reverse(word)));
    }
}

