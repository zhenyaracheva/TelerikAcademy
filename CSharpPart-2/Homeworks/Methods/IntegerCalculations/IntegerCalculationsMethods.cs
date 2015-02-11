//Problem 14. Integer calculations

//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
//Use variable number of arguments.

using System;
using System.Linq;

class IntegerCalculationsMethods
{
    static void Main()
    {
        Console.WriteLine("Please, enter an array of numbers (separate by space):");
        int[] numbers = CreateArrayOfNumbers();

        Console.WriteLine("Min number: {0}", MinValue(numbers));
        Console.WriteLine("Max number: {0}", MaxValue(numbers));
        Console.WriteLine("Average: {0}",AverageValue(numbers));
        Console.WriteLine("Sum: {0}", Sum(numbers));
        Console.WriteLine("Product: {0}", Product(numbers));
    }

    private static long Product(int[] numbers)
    {
        long product = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        return product;
    }

    private static int Sum(int[] numbers)
    {
        return numbers.Sum();
    }

    private static double AverageValue(int[] numbers)
    {
        return numbers.Average();
    }

    private static int MaxValue(int[] numbers)
    {
        return numbers.Max();
    }

    private static int MinValue(int[] numbers)
    {
        return numbers.Min();
    }

    private static int[] CreateArrayOfNumbers()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (input.Length<=0)
        {
            Console.Write("Empty array! Try again: ");
            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return input.Select(int.Parse).ToArray();
    }
}

