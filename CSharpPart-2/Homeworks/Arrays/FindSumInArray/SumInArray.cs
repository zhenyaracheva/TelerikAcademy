//Problem 10. Find sum in array

//Write a program that finds in given array of integers a sequence of given sum S (if present).
//Example:

//      array	         S	    result
//4, 3, 1, 4, 2, 5, 8	 11	    4, 2, 5

using System;
using System.Collections.Generic;
using System.Text;

class SumInArray
{
    static void Main()
    {
        Console.WriteLine("Please, enter numbers of array (separated by space or \",\"): ");
        string[] inputArray = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        while (inputArray.Length <= 0)
        {
            Console.WriteLine("Empty array! Try again!");
            inputArray = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        Console.Write("Please, enter sum: ");
        int sumNeeded = int.Parse(Console.ReadLine());

        int[] arrayOfNumbers = CreateArrayOfNumners(inputArray);
        List<string> solutions = new List<string>();

        for (int startIndex = 0; startIndex < arrayOfNumbers.Length; startIndex++)
        {
            int currentSum = 0;
            StringBuilder result = new StringBuilder();

            for (int endIndex = startIndex; endIndex < arrayOfNumbers.Length; endIndex++)
            {
                currentSum += arrayOfNumbers[endIndex];

                if (sumNeeded == currentSum)
                {
                    result.AppendFormat("{0}, ", arrayOfNumbers[endIndex]);
                    result.Length -= 2;
                    solutions.Add(result.ToString());
                    break;
                }
                else if (sumNeeded > currentSum)
                {
                    result.AppendFormat("{0}, ", arrayOfNumbers[endIndex]);
                }
            }
        }

        if (solutions.Count > 0)
        {
            foreach (var solution in solutions)
            {
                Console.WriteLine(solutions);
            }
        }
        else
        {
            Console.WriteLine("No array of integers has sum {0}", sumNeeded);
        }


    }

    private static int[] CreateArrayOfNumners(string[] inputArray)
    {
        int[] array = new int[inputArray.Length];

        for (int i = 0; i < inputArray.Length; i++)
        {
            array[i] = int.Parse(inputArray[i]);
        }

        return array;
    }
}

