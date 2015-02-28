//Problem 2. Concatenate text files

//Write a program that concatenates two text files into another text file.

using System;
using System.IO;

class SolveConcatenateTextFiles
{
    static void Main()
    {

        StreamWriter writer = new StreamWriter(@"..\..\thirdText.txt");

        using (writer)
        {
            using (StreamReader firstReader = new StreamReader(@"..\..\firstText.txt"))
            {
                string line = firstReader.ReadLine();

                while (line != null)
                {
                    writer.WriteLine(line);
                    line = firstReader.ReadLine();
                }
            }

            using (StreamReader secondReader = new StreamReader(@"..\..\secondText.txt"))
            {
                string line = secondReader.ReadLine();

                while (line != null)
                {
                    writer.WriteLine(line);
                    line = secondReader.ReadLine();
                }
            }
        }

        Console.WriteLine("Concatenated text files is done!");
    }
}
