//Problem 5. Sort by string length

//You are given an array of strings. Write a method that sorts the array by the length 
//of its elements (the number of characters composing them).

using System;

class SortArrayByStringLength
{
    static void Main()
    {
        Console.WriteLine("Please, enter an array of strings (separate strings by space):");
        string[] words = CheckArray();
        Array.Sort(words);

        int minLenght = words[0].Length;

        for (int i = 0; i < words.Length - 1; i++)
        {
            minLenght = words[i].Length;

            for (int j = i + 1; j < words.Length; j++)
            {
                if (minLenght > words[j].Length)
                {
                    string temp = words[i];
                    words[i] = words[j];
                    words[j] = temp;
                    minLenght = words[i].Length;
                }
            }

            Array.Sort(words, i + 1, words.Length - i - 1);
        }
        Console.WriteLine("Sorted array: ");
        Console.WriteLine(string.Join(", ", words));

    }

    private static string[] CheckArray()
    {
        string[] line = Console.ReadLine().Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        while (line.Length <= 0)
        {
            Console.Write("Array lenght must be bigger tnah 0! Try again: ");
            line = Console.ReadLine().Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return line;
    }
}

