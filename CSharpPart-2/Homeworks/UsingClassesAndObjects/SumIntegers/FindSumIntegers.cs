//Problem 6. Sum integers

//You are given a sequence of positive integer values written into a string, separated by spaces.
//Write a function that reads these values from given string and calculates their sum.
//Example:

//      input	        output
//"43 68 9 23 318"	    461

using System;
using System.Linq;

class FindSumIntegers
{
    static void Main()
    {
        Console.WriteLine("Please, enter a sequence of positive integer values separated by spaces:");
        string sequence = Console.ReadLine();
        long sum = SumIntegers(sequence);
        Console.WriteLine(sum);
    }

    private static long SumIntegers(string sequence)
    {
        uint[] integers = sequence.Split(' ').Select(uint.Parse).ToArray();
        long sum = 0;

        for (int i = 0; i < integers.Length; i++)
        {
            sum += integers[i];
        }

        return sum;
    }
}

