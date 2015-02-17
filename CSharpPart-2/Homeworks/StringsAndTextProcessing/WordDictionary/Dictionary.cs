//Problem 14. Word dictionary

//A dictionary is stored as a sequence of text lines containing words and their explanations.
//Write a program that enters a word and translates it by using the dictionary.
//Sample dictionary:

//input	            output
//.NET	            platform for applications from Microsoft
//CLR	            managed execution environment for .NET
//namespace	        hierarchical organization of classes

using System;
using System.Collections.Generic;

class Dictionary
{
    static Dictionary<string, string> dict = new Dictionary<string, string>();
    static void Main()
    {
        Console.Write("Plaese, enter a word(.NET,CLR,namespace): ");
        string word = Console.ReadLine();
        dict[".NET"] = "platform for applications from Microsoft";
        dict["CLR"] = "managed execution environment for .NET";
        dict["namespace"] = "hierarchical organization of classes";

        if (dict.ContainsKey(word))
        {
            Console.Write("{0}: ", word);
            Console.WriteLine(dict[word]);
        }
        else
        {
            Console.Write("Not Found!Enter description: ");
            AddWord(word);
            Console.WriteLine("{0}: {1}", word, dict[word]);
        }

    }

    static void AddWord(string word)
    {
        string description = Console.ReadLine();
        dict.Add(word, description);
    }
}

