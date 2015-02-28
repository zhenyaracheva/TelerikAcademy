//Problem 6. Save sorted names

//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
//Example:

//input.txt	           output.txt
//Ivan                  George
//Peter                 Ivan 
//Maria                 Maria 
//George	            Peter 
///

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SaveSaveSortedNames
{
    static void Main()
    {
        List<string> names = new List<string>();

        using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
        {
            string name = reader.ReadLine();

            while (name != null)
            {
                names.Add(name);
                name = reader.ReadLine();
            }
        }

        names.Sort();

        using (StreamWriter writer = new StreamWriter(@"..\..\output.txt"))
        {
            foreach (var name in names)
            {
                writer.WriteLine(name);
            }
        }

        Console.WriteLine("Names are sorted!");
    }
}
