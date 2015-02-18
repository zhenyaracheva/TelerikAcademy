//Problem 18. Extract e-mails

//Write a program for extracting all email addresses from given text.
//All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string RegexPattern = @"\b[A-Z0-9._-]+@[A-Z0-9][A-Z0-9.-]{0,61}[A-Z0-9]\.[A-Z.]{2,6}\b";
        string str = Console.ReadLine();
        var matches = Regex.Matches(str, RegexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        for (int i = 0; i < matches.Count; i++)
        {
            Console.WriteLine(matches[i]);
        }
    }
}