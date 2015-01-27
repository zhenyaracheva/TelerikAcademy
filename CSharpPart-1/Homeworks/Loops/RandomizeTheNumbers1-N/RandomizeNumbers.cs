//Problem 12.* Randomize the Numbers 1…N

//Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.

using System;
using System.Collections.Generic;

class RandomizeNumbers
{
    static void Main()
    {
        Console.Write("Please, enter a positive integer: ");
        int number = int.Parse(Console.ReadLine());
        Random rand = new Random();
        List<int> result = new List<int>();

        while (result.Count != number)
        {
            int nextNumber = rand.Next(1, number + 1);

            if (!result.Contains(nextNumber))
            {
                result.Add(nextNumber);
            }
        }

        for (int i = 0; i < result.Count; i++)
        {
            Console.Write("{0} ", result[i]);
        }

        Console.WriteLine();
    }
}
