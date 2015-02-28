//Problem 12. Remove words

//Write a program that removes from a text file all words listed in given another text file.
//Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class SolveRemoveWords
{
    static void Main()
    {
        try
        {
            List<string> words = new List<string>();

            using (StreamReader reader = new StreamReader(@"..\..\firstText.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    var matches = Regex.Matches(line, @"\b\w+\b");

                    foreach (var match in matches)
                    {
                        words.Add(match.ToString().ToLower());
                    }

                    line = reader.ReadLine();
                }
            }

            StringBuilder result = new StringBuilder();

            using (StreamReader reader = new StreamReader(@"..\..\secondText.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    var matches = Regex.Matches(line, @"\b\w+\b");
                    bool emptyLine = true;

                    for (int i = 0; i < matches.Count; i++)
                    {
                        if (!words.Contains(matches[i].ToString().ToLower()))
                        {
                            result.Append(matches[i] + " ");
                            emptyLine = false;
                        }
                    }

                    if (!emptyLine)
                    {
                        result.Length--;
                        result.AppendLine();
                    }

                    if (line == string.Empty)
                    {
                        if (result.Length > 0)
                        {
                            result.AppendLine();
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(@"..\..\resultText.txt"))
            {
                writer.WriteLine(result);
            }

            Console.WriteLine("Done!");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FieldAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

