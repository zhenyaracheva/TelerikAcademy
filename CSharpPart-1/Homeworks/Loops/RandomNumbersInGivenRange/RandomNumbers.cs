//Problem 11. Random Numbers in Given Range

//Write a program that enters 3 integers n, min and max (min != max) and prints n random numbers in the range [min...max].

using System;

class RandomNumbers
{
    static Random rand = new Random();

    static void Main()
    {
        Console.Write("Please, enter numbers count tou want to print: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please, enter min number: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Please, enter max number: ");
        int max = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", rand.Next(min, max + 1));
        }
    }
}

