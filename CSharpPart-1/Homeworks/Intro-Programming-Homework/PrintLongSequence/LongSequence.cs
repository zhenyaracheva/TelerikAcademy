//Problem 16. Print Long Sequence

//Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
//You might need to learn how to use loops in C# (search in Internet).

using System;
using System.Text;

class LongSequence
{
    static void Main()
    {
        int numbersCount = 1000;

        StringBuilder result = new StringBuilder();

        for (int i = 2; i < numbersCount + 2; i++)
        {
            if (i % 2 == 0)
            {
                result.AppendFormat("{0}, ", i);
            }
            else
            {
                result.AppendFormat("-{0}, ", i);
            }
        }

        result.Length -= 2;
        Console.WriteLine(result);
    }
}

