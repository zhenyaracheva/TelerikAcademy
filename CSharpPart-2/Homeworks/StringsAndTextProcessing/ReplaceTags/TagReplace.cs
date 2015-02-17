//Problem 15. Replace tags

//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

using System;
using System.Text.RegularExpressions;

class TagReplace
{
    static void Main()
    {
        Console.WriteLine("Please, enter a tag <a href=\"…\">…</a>: ");
        string tag = Console.ReadLine();
        string patternOriginal = @"<a href=""(.*?)"">(.*?)</a>";
        string patternReplace = @"[URL=$1]$2[/URL]";

        var match = Regex.Replace(tag, patternOriginal, patternReplace);
        Console.WriteLine(match);
    }
}

