//Problem 9. Frequent number

//Write a program that finds the most frequent number in an array.
//Example:

//                  input	                    result
//4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3	        4 (5 times)

using System;
using System.Collections.Generic;

class FindFrequentNumber
{
    static void Main()
    {
        Console.WriteLine("Please, enter numbers of array (separated by space or \",\"): ");
        string[] inputArray = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> solutions = new List<string>();

        while (inputArray.Length <= 0)
        {
            Console.WriteLine("Empty array! Try again!");
            inputArray = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        Array.Sort(inputArray);

        string lastString = inputArray[0];
        string maxString = string.Empty;
        int currentCount = 0;
        int maxCount = 0;

        for (int i = 0; i < inputArray.Length; i++)
        {
            while (lastString == inputArray[i])
            {
                currentCount++;

                if (i + 1 < inputArray.Length)
                {
                    i++;
                }
                else
                {
                    break;
                }
            }

            if (maxCount < currentCount)
            {
                maxCount = currentCount;
                currentCount = 0;
                maxString = lastString;
                solutions.Clear();
                solutions.Add(maxString);
            }
            else if (maxCount == currentCount)
            {
                solutions.Add(lastString);
            }

            lastString = inputArray[i];
            currentCount = 0;

            if (i != inputArray.Length - 1)
            {
                i--;
            }
        }

        if (lastString == inputArray[inputArray.Length - 1])
        {
            currentCount++;
        }

        if (maxCount < currentCount)
        {
            maxCount = currentCount;
            currentCount = 0;
            maxString = lastString;
            solutions.Clear();
            solutions.Add(maxString);
        }
        else if (maxCount == currentCount)
        {
            if (!solutions.Contains(lastString))
            {
                solutions.Add(lastString);
            }
        }


        if (solutions.Count == inputArray.Length)
        {
            Console.WriteLine("No repeated parts!");
        }
        else
        {
            foreach (var solution in solutions)
            {
                Console.WriteLine("{0} - {1} times", solution, maxCount);
            }
        }
    }
}

