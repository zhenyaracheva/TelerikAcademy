//Problem 16.* Subset with sum S

//We are given an array of integers and a number S.
//Write a program to find if there exists a subset of the elements of the array that has a sum S.
//Example:

//       input array	    S	 result
//2, 1, 2, 4, 3, 5, 2, 6	14	 yes

using System;
using System.Collections.Generic;

class FindSubsetWithSumS
{
    static long[] arrayOfNumbers = { 7, 3, 1, 7, 5 };
    static int counter = 0;

    static void Main()
    {
        Console.WriteLine("Please, enter numbers of array (separated by space or \",\"): ");
        string[] inputArray = CheckIsValidInput();
        arrayOfNumbers = CreateArray(inputArray);

        Console.Write("Please, enter subset sum: ");
        long sum = long.Parse(Console.ReadLine());
        long currentSum = 0;

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            FindSubsetSum(sum, currentSum, i);
        }

        if (counter == 0)
        {
            Console.WriteLine("No subset sum of {0}!", sum);
        }
    }

    private static void FindSubsetSum(long sum, long currentSum, int index)
    {
        if (index >= arrayOfNumbers.Length)
        {
            return;
        }

        for (int i = index; i < arrayOfNumbers.Length; i++)
        {
            currentSum += arrayOfNumbers[i];

            if (currentSum > sum)
            {
                if (i + 1 >= arrayOfNumbers.Length)
                {
                    return;
                }

                currentSum -= arrayOfNumbers[i];
                FindSubsetSum(sum, currentSum, i + 1);

            }
            else if (currentSum < sum)
            {
                if (i + 1 >= arrayOfNumbers.Length)
                {
                    return;
                }

                FindSubsetSum(sum, currentSum, i + 1);
                currentSum -= arrayOfNumbers[i];
            }
            else if (currentSum == sum)
            {
                Console.WriteLine("Yes!");
                counter++;
                Environment.Exit(0);
            }
        }
    }

    private static long[] CreateArray(string[] arrayOfStrings)
    {
        long[] arrayOfNumbers = new long[arrayOfStrings.Length];

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = long.Parse(arrayOfStrings[i]);
        }

        return arrayOfNumbers;
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
}

