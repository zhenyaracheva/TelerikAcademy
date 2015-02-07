//Problem 18.* Remove elements from array

//Write a program that reads an array of integers and removes from it a minimal number of elements in such a way that the 
//remaining array is sorted in increasing order.
//Print the remaining sorted array.
//Example:

//          input	               result
//6, 1, 4, 3, 0, 3, 6, 4, 5	    1, 3, 3, 4, 5

using System;
using System.Collections.Generic;

class RemoveElements
{
    static List<int> maxSolution = new List<int>();

    static void Main()
    {
        Console.WriteLine("Please, enter numbers of array (separated by space or \",\"): ");
        string[] inputArray = CheckIsValidInput();
        int[] arrayOfNumbers = CreateArray(inputArray);

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            FindCombination(i, arrayOfNumbers, new List<int>());
        }

        Console.Write("Solution: ");
        if (arrayOfNumbers.Length == 1)
        {
            Console.Write(arrayOfNumbers[0]);
        }
        else
        {
            for (int i = 0; i < maxSolution.Count; i++)
            {
                Console.Write("{0} ", maxSolution[i]);
            }
        }

        Console.WriteLine();
    }

    private static void FindCombination(int index, int[] numbers, List<int> currentSolution)
    {
        if (index >= numbers.Length)
        {
            if (currentSolution.Count > maxSolution.Count)
            {
                maxSolution.Clear();

                for (int j = 0; j < currentSolution.Count; j++)
                {
                    maxSolution.Add(currentSolution[j]);
                }
            }

            return;
        }

        for (int i = index; i < numbers.Length; i++)
        {
            if (currentSolution.Count == 0)
            {
                currentSolution.Add(numbers[i]);
            }
            else
            {
                if (numbers[i] >= currentSolution[currentSolution.Count - 1])
                {
                    currentSolution.Add(numbers[i]);
                    FindCombination(i + 1, numbers, currentSolution);
                    currentSolution.RemoveAt(currentSolution.Count - 1);
                }
            }
        }

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

    private static int[] CreateArray(string[] arrayOfStrings)
    {
        int[] arrayOfNumbers = new int[arrayOfStrings.Length];

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = int.Parse(arrayOfStrings[i]);
        }

        return arrayOfNumbers;
    }
}

