//Problem 1. Odd lines

//Write a program that reads a text file and prints on the console its odd lines

using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\test.txt");

        using (reader)
        {
            int lineCount = 1;
            string line = reader.ReadLine();

            while (line != null)
            {

                if (lineCount % 2 == 1)
                {
                    Console.WriteLine(line);
                }

                line = reader.ReadLine();
                lineCount++;
            }
        }
    }
}

