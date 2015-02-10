//Problem 9. Sorting array

//Write a method that return the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending / descending order.

using System;
using System.Collections.Generic;
using System.Linq;

class SortingArrayMethod
{
    static void Main()
    {
        Console.WriteLine("Please, enter an array of integers (separate by space):");
        string[] arrayOfStrings = CheckArray();
        List<int> arrayOfNumbers = ConvertArrayToInt(arrayOfStrings);

        Console.Write("Plsease, enter an index: ");
        int index = int.Parse(Console.ReadLine());

        int maxInRange = FindMax(arrayOfNumbers, index);
        Console.WriteLine(maxInRange);

        Console.Write("Please, enter A (ascending) or D (descending) sorting: ");
        string direction = Console.ReadLine();
        arrayOfNumbers = SortArray(arrayOfNumbers, direction);
        PrintArray(arrayOfNumbers);
    }

    private static void PrintArray(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine(
            );
    }

    private static List<int> SortArray(List<int> numbers, string direction)
    {
        List<int> sorted = new List<int>();

        while (numbers.Count > 0)
        {
            int max = FindMax(numbers, 0);
            numbers.Remove(max);
            sorted.Add(max);
        }

        if (direction == "A")
        {
            sorted.Reverse();
            return sorted;
        }
        else if (direction == "D")
        {
            return sorted;
        }
        else
        {
            throw new ArgumentException("Invalid direction!");
        }
    }

    private static int FindMax(List<int> numbers, int index)
    {
        int max = numbers[index];

        for (int i = index + 1; i < numbers.Count; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }

        return max;
    }

    private static List<int> ConvertArrayToInt(string[] arrayOfStrings)
    {
        List<int> numbers = new List<int>();

        for (int i = 0; i < arrayOfStrings.Length; i++)
        {
            numbers.Add(int.Parse(arrayOfStrings[i]));
        }

        return numbers;
    }

    private static string[] CheckArray()
    {
        string[] arrayOfStrings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (arrayOfStrings.Length <= 0)
        {
            Console.WriteLine("Empty array! Try again:");
            arrayOfStrings = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return arrayOfStrings;
    }
}

