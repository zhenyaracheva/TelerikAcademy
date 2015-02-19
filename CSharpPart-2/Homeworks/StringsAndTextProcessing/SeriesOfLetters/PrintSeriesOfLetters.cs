//Problem 23. Series of letters

//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
//Example:

//        input	            output
//aaaaabbbbbcdddeeeedssaa	abcdedsa

using System;
using System.Linq;
using System.Text;

class PrintSeriesOfLetters
{
    static void Main()
    {
        Console.Write("Please, enter a string: ");
        string input = Console.ReadLine();

        if (input.Length == 0)
        {
            Console.WriteLine("Empty input!");
            return;
        }

        string newString = ClearRepeatedLetters(input);
        Console.WriteLine(newString);
    }

    private static string ClearRepeatedLetters(string text)
    {
        var sb = new StringBuilder();
        sb.Append(text[0]);

        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] != text[i - 1])
            {
                sb.Append(text[i]);
            }
        }

        return sb.ToString();
    }
}
