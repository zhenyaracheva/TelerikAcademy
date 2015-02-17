//Problem 9. Forbidden words

//We are given a string containing a list of forbidden words and a text containing some of these words.
//Write a program that replaces the forbidden words with asterisks.
//Example text: Microsoft announced its next generation PHP compiler today. It is based on .NET 
//Framework 4.0 and is implemented as a dynamic language in CLR.
//Forbidden words: PHP, CLR, Microsoft
//The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 
//4.0 and is implemented as a dynamic language in ***.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FindForbiddenWords
{
    static void Main()
    {
        Console.Write("Please, enter text: ");
        string input = SeparateInput();
        string[] text = input.Split(new char[] { ' ' });
        Console.Write("Please, enter forbidden words(separate by comma): ");
        List<string> words = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            if (words.Contains(text[i]))
            {
                output.Append(new string('*', text[i].Length) + " ");
            }
            else
            {
                output.Append(text[i] + " ");
            }
        }

        output = ClearText(output);

        Console.WriteLine(output.ToString().Trim());
    }

    private static StringBuilder ClearText(StringBuilder output)
    {
        List<char> signs = new List<char>() { '.', ',', '!', '?', '\\', '/', '\"', '\'', '-' };

        for (int i = 0; i < output.Length; i++)
        {
            if (signs.Contains(output[i]))
            {
                output.Remove(i + 1, 1);
                output.Remove(i - 1, 1);
                i++;
            }
        }

        return output;
    }

    private static string SeparateInput()
    {
        List<char> signs = new List<char>() { '.', ',', '!', '?', '\\', '/', '\"', '\'', '*', '-' };
        var text = new StringBuilder(Console.ReadLine());

        for (int i = 0; i < text.Length; i++)
        {
            if (signs.Contains(text[i]))
            {
                text.Insert(i + 1, " ");
                text.Insert(i, " ");
                i++;
            }
        }

        return text.ToString();
    }
}
