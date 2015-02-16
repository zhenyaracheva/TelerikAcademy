//Problem 4. Sub-string in text

//Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
//Example:
//The target sub-string is in
//The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. 
//So we are drinking all the day. We will move out of it in 5 days.
//The result is: 9

using System;
using System.Linq;
using System.Text.RegularExpressions;

class FindSubStringInText
{
    static void Main()
    {
        Console.WriteLine("Please, enter text:");
        string text = Console.ReadLine();
        Console.Write("Please,enter a sub-string you want to find: ");
        string subString = Console.ReadLine();

        Match sensitive = Regex.Match(text, subString);
        int counter = 0;
        while (sensitive.Success)
        {
            counter++;
            sensitive = sensitive.NextMatch();
        }
        Console.WriteLine("Case sensitive:");
        Console.WriteLine("Sub-string {0} was found {1} times.", subString, counter);

        Match unsensitive = Regex.Match(text.ToLower(), subString.ToLower());
        int counterUnsensitive = 0;
        while (unsensitive.Success)
        {
            counterUnsensitive++;
            unsensitive = unsensitive.NextMatch();
        }
        Console.WriteLine("Case insensitive:");
        Console.WriteLine("Sub-string {0} was found {1} times.", subString, counterUnsensitive);
    }
}
