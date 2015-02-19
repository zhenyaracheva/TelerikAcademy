//Problem 20. Palindromes

//Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe. 

using System;
using System.Text.RegularExpressions;

class FindPalindromes
{
    static void Main()
    {
        Console.Write("Please, enter text: ");
        string text = Console.ReadLine();
        var matches = Regex.Matches(text, @"\b\w+\b");

        foreach (var match in matches)
        {
            if (IsPalindrom(match.ToString()))
            {
                Console.WriteLine(match);

            }
        }
    }

    public static bool IsPalindrom(string str)
    {
        int i = 0;
        int j = str.Length - 1;

        while (i < j)
        {
            if (str[i] != str[j])
                return false;

            i++;
            j--;
        }

        return true;
    }
}

