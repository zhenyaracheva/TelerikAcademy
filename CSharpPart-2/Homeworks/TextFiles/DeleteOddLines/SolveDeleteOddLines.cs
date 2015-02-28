//Problem 9. Delete odd lines

//Write a program that deletes from given text file all odd lines.
//The result should be in the same file.

using System;
using System.IO;
using System.Text;

class SolveDeleteOddLines
{
    static void Main()
    {
        StringBuilder result = new StringBuilder();

        using (StreamReader reader = new StreamReader(@"..\..\text.txt"))
        {
            string line = reader.ReadLine();
            int count = 1;

            while (line != null)
            {
                if (count % 2 == 0)
                {
                    result.AppendLine(line);
                }

                line = string.Empty;
                line = reader.ReadLine();
                count++;
            }
        }

        using (StreamWriter writer = new StreamWriter(@"..\..\text.txt"))
        {
            writer.WriteLine(result);
        }

        Console.WriteLine("Done!");
    }
}
