//Problem 15.* Number calculations

//Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
//Use generic method (read in Internet about generic methods in C#).

using System;
using System.Linq;

class Calculations
{
    static void Main()
    {
        Console.WriteLine("Please, enter an array of numbers (separate by space):");
        dynamic[] numbers = CreateArrayOfNumbers();

        Console.WriteLine("Min number: {0}", MinValue(numbers));
    }

    private static T Product<T>(params T[] numbers)
    {
        dynamic product = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        return product;
    }

    private static T Sum<T>(params T[] numbers)
    {
        dynamic sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    private static T AverageValue<T>(params T[] numbers)
    {
        dynamic average = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            average += numbers[i];
        }

        return average / numbers.Length;
    }

    private static T MaxValue<T>(params T[] numbers)
    {
        return numbers.Max();
    }

    private static T MinValue<T>(params T[] numbers)
    {
        return numbers.Min();
    }

    private static string[] CreateArrayOfNumbers()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (input.Length <= 0)
        {
            Console.Write("Empty array! Try again: ");
            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return input;
    }
}

