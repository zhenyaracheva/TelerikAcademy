//Problem 7. Replace sub-string

//Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file.
//Ensure it will work with large files (e.g. 100 MB).  

using System;
using System.Linq;
using System.IO;
using System.Text;

class SolveReplaceSubString
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\output.txt"))
            {
                string line = reader.ReadLine();
                StringBuilder result = new StringBuilder();

                while (line != null)
                {
                    result.AppendLine(line.Replace("start", "finish"));
                    line = reader.ReadLine();
                }

                writer.WriteLine(result);
            }
        }

        Console.WriteLine("Done!");
    }
}

