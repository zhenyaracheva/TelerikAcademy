//Problem 8. Extract sentences

//Write a program that extracts from a given text all sentences containing given word.
//Example:

//The word is: in
//The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. 
//So we are drinking all the day. We will move out of it in 5 days.
//The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.
//Consider that the sentences are separated by . and the words – by non-letter symbols.

using System;
using System.Text.RegularExpressions;
class ExtractingSentences
{
    static void Main()
    {
        Console.WriteLine("Please, enter text:");
        string input = Console.ReadLine();
        input = input.Replace(".", " . ");
        string[] text = input.Split('.');

        Console.Write("Please, enter a word: ");
        string word = Console.ReadLine();
        string pattern = " " + word + " ";

        for (int i = 0; i < text.Length; i++)
        {
            Match match = Regex.Match(text[i], pattern);

            while (match.Success)
            {
                match = match.NextMatch();
                Console.WriteLine(text[i].Trim() + ".");
                break;
            }
        }
    }
}

