//Problem 13. Reverse sentence

//Write a program that reverses the words in given sentence.
//Example:

//              input	                                output
//C# is not C++, not PHP and not Delphi!	Delphi not and PHP, not C++ not is C#!

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintReverseSentence
{
    static void Main()
    {
        Console.Write("Please, eneter a sentence: ");
        string input = Console.ReadLine();
        char end = input[input.Length - 1];
        input = input.Remove(input.Length - 1);
        input = input.Replace(",", " , ");
        string[] test = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<int> commaPositions = new List<int>();

        for (int i = 0; i < test.Length; i++)
        {
            if (test[i] == ",")
            {
                commaPositions.Add(i);
            }
        }

        Array.Reverse(test);
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < test.Length; i++)
        {
            if (test[i]==",")
            {
                continue;
            }
            else if (commaPositions.Contains(i))
            {
                commaPositions.Remove(i);
                i--;
                output.Length--;
                output.Append(", ");
            }
            else
            {
                output.Append(test[i]+" ");
            }
        }
        output.Length--;
        output.Append(end);
        Console.WriteLine(output);
    }
}

