//Problem 10. Unicode characters

//Write a program that converts a string to a sequence of C# Unicode character literals.
//Use format strings.
//Example:

//input	          output
//Hi!	    \u0048\u0069\u0021

using System;
using System.Text;

class PrintUnicodeCharacters
{
    static void Main()
    {
        Console.Write("Please, enter string: ");
        string input = Console.ReadLine();
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            result.Append(string.Format(@"\u{0:x4}", (int)input[i]));
        }

        Console.WriteLine(result);
    }
}

