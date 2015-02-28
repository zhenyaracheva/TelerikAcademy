//Problem 13. Count words

//Write a program that reads a list of words from the file words.txt and finds how many times each of the 
//words is contained in another file test.txt.
//The result should be written in the file result.txt and the words should be sorted by the number of
//their occurrences in descending order.
//Handle all possible exceptions in your methods.

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class SolveCountWords
{
    static void Main()
    {
        try
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(@"..\..\words.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    dict[line.ToLower()] = 0;
                    line = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(@"..\..\test.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    var words = Regex.Matches(line, @"\b\w+\b", RegexOptions.IgnoreCase);

                    foreach (var word in words)
                    {
                        if (dict.ContainsKey(word.ToString().ToLower()))
                        {
                            dict[word.ToString().ToLower()]++;
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            var sorded = dict.OrderByDescending(x => x.Value);
            using (StreamWriter writer = new StreamWriter(@"..\..\result.txt"))
            {
                foreach (var word in sorded)
                {
                    writer.WriteLine("{0} - {1}", word.Key, word.Value);
                }
            }

            Console.WriteLine("Done!");
        }
        catch (FieldAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FileNotFoundException ex)
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

