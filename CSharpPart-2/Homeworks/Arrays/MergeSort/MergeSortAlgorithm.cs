//Problem 13.* Merge sort

//Write a program that sorts an array of integers using the Merge sort algorithm.

using System;
using System.Collections.Generic;

class MergeSortAlgorithm
{
    static void Main()
    {
        Console.WriteLine("Please, enter numbers of array (separated by space or \",\"): ");
        string[] inputArray = CheckIsValidInput();

        List<int> arrayOfNumbers = CreateListOfArray(inputArray);

        arrayOfNumbers = MergeSort(arrayOfNumbers);

        for (int i = 0; i < arrayOfNumbers.Count; i++)
        {
            Console.Write("{0} ", arrayOfNumbers[i]);
        }

        Console.WriteLine();
    }

    private static List<int> CreateListOfArray(string[] array)
    {
        List<int> list = new List<int>();

        for (int i = 0; i < array.Length; i++)
        {
            list.Add(int.Parse(array[i]));
        }

        return list;
    }

    private static string[] CheckIsValidInput()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        while (input.Length <= 0)
        {
            Console.WriteLine("Empty array! Try again!");
            input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return input;
    }

    private static List<int> MergeSort(List<int> arrayOfNumbers)
    {
        if (arrayOfNumbers.Count <= 1)
        {
            return arrayOfNumbers;
        }

        List<int> left = new List<int>();
        List<int> right = new List<int>();
        var middle = arrayOfNumbers.Count / 2;

        for (int i = 0; i < arrayOfNumbers.Count; i++)
        {
            if (i < middle)
            {
                left.Add(arrayOfNumbers[i]);
            }
            else
            {
                right.Add(arrayOfNumbers[i]);
            }
        }

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        var result = new List<int>();
        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            else if (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            else if (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }

        return result;
    }
}

