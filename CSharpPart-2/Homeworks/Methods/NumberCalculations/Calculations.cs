//Problem 15.* Number calculations

//Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
//Use generic method (read in Internet about generic methods in C#).

using System;
using System.Linq;

class Calculations
{
    static void Main()
    {
        Console.WriteLine("Methods with no floating point numbers:");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Min value: {0}", MinValue(1, 2, 3));
        Console.WriteLine("Max value: {0}", MaxValue(1, 2, 3));
        Console.WriteLine("Average: {0}", AverageValue(1, 2, 3));
        Console.WriteLine("Sum: {0}", Sum(1, 2, 3));
        Console.WriteLine("Product: {0}", Product(1, 2, 3));
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Methods with floating piont numbers:");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Min value: {0}", MinValue(1.2, 2.2, 3.2));
        Console.WriteLine("Max value: {0}", MaxValue(1.2, 2.2, 3.2));
        Console.WriteLine("Average: {0}", AverageValue(1.2, 2.2, 3.2));
        Console.WriteLine("Sum: {0}", Sum(1.2, 2.2, 3.2));
        Console.WriteLine("Product: {0}", Product(1.2, 2.2, 3.2));
    }

    private static T Product<T>(params T[] numbers)
    {
        dynamic product = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            product *= (dynamic)numbers[i];
        }

        return product;
    }

    private static T Sum<T>(params T[] numbers)
    {
        dynamic sum = 0;


        for (int i = 0; i < numbers.Length; i++)
        {
            sum += (dynamic)numbers[i];
        }

        return sum;
    }

    private static T AverageValue<T>(params T[] numbers)
    {
        dynamic average = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            average += (dynamic)numbers[i];
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
}

