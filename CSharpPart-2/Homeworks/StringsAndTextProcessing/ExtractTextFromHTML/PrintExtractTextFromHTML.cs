//Problem 25. Extract text from HTML

//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
//Example input:

//<html>
//  <head><title>News</title></head>
//  <body><p><a href="http://academy.telerik.com">Telerik
//    Academy</a>aims to provide free real-world practical
//    training for young people who want to turn into
//    skilful .NET software engineers.</p></body>
//</html>
//Output:

//Title: News

//Text: Telerik Academy aims to provide free real-world practical training for young people who want to 
//turn into skilful .NET software engineers.

using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;


class PrintExtractTextFromHTML
{
    static void Main()
    {
        string html = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.</p></body></html>";

        int count = 1;
        if (html.Contains("title"))
        {
            count = 0;
        }
        var matches = Regex.Matches(html, @"(?<=^|>)[^><]+?(?=<|$)");

        StringBuilder result = new StringBuilder();

        foreach (var match in matches)
        {
            if (count == 0)
            {
                Console.WriteLine("Title: {0}", match);
                Console.WriteLine();
                count++;
            }
            else if (count == 1)
            {
                result.AppendFormat("Text: {0} ", match);
                count++;
            }
            else
            {
                result.AppendFormat("{0} ", match);
            }
        }

        Console.WriteLine(result.ToString().Trim());
    }
}

