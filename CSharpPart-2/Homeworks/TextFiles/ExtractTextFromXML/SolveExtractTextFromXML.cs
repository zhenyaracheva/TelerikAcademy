//Problem 10. Extract text from XML

//Write a program that extracts from given XML file all the text without the tags.
//Example:
//<?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3"><interest>Games
//</interest><interest>C#</interest><interest>Java</interest></interests></student>

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class SolveExtractTextFromXML
{
    static void Main()
    {
        StringBuilder result = new StringBuilder();

        using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                var matches = Regex.Matches(line, @">\w+<");
                foreach (var match in matches)
                {
                    result.Append(match.ToString().Replace(">", string.Empty).Replace("<", string.Empty));
                    result.Append(" ");
                }

                line = reader.ReadLine();
            }
        }

        using (StreamWriter writer = new StreamWriter(@"..\..\output.txt"))
        {
            result.Length--;
            writer.WriteLine(result);
        }

        Console.WriteLine("Done!");
    }
}

