//Problem 11. Prefix "test"

//Write a program that deletes from a text file all words that start with the prefix test.
//Words contain only the symbols 0…9, a…z, A…Z, _.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class SolvePrefixTest
{
    static void Main()
    {
        try
        {
            StringBuilder result = new StringBuilder();

            using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
            {
                string line = reader.ReadLine();
                CheckValidLine(line);

                while (line != null)
                {
                    var matches = Regex.Replace(line, @"\btest\w+\b ", string.Empty);
                    result.AppendLine(matches);
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(@"..\..\output.txt"))
            {
                writer.WriteLine(result);
            }

            Console.WriteLine("Done!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Have a nice day :)");
        }

    }

    private static void CheckValidLine(string line)
    {
        string[] words = line.Split(new[] { ' ', ',', '.', '!', '?', '-' });

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if (!char.IsLetterOrDigit(words[i][j]) && words[i][j] != '_')
                {
                    throw new ArgumentException("Invalid word in text.");
                }
            }
        }
    }
}

