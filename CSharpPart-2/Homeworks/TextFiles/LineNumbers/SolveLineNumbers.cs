//Problem 3. Line numbers

//Write a program that reads a text file and inserts line numbers in front of each of its lines.
//The result should be written to another text file.

using System;
using System.IO;

class SolveLineNumbers
{
    static void Main()
    {

        using (StreamReader reader = new StreamReader(@"..\..\text.txt"))
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\textWithLines.txt"))
            {
                int count = 1;
                string line = reader.ReadLine();

                while (line != null)
                {
                    writer.WriteLine("{0}. {1}", count, line);
                    line = reader.ReadLine();
                    count++;
                }
            }
        }

        Console.WriteLine("Done!");
    }
}

