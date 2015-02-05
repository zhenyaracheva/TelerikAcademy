//Problem 8. Maximal sum

//Write a program that finds the sequence of maximal sum in given array.
//Example:

//            input	                          result
//2, 3, -6, -1, 2, -1, 6, 4, -8, 8	        2, -1, 6, 4

using System;
using System.Text;

class FindMaximalSum
{
    static void Main()
    {
        Console.WriteLine("Please, enter numbers of array (separated by space or \",\"): ");
        string[] stringArray = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        while(stringArray.Length<=0)
        {
            Console.WriteLine("Empty array! Try again!");
            stringArray = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        int[] arrayOfNumbers = new int[stringArray.Length];

        for (int i = 0; i < stringArray.Length; i++)
        {
            arrayOfNumbers[i] = int.Parse(stringArray[i]);
        }

        int maxSum = 0;
        int currentSum = 0;
        int startIndex = 0;
        int endIndex = 0;
        int seqStart = 0;
        int seqEnd = 0;

        while (endIndex < arrayOfNumbers.Length)
        {
            currentSum = currentSum + arrayOfNumbers[endIndex];

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                seqStart = startIndex;
                seqEnd = endIndex;
            }
            else if (currentSum < 0)
            {
                startIndex = endIndex + 1;
                currentSum = 0;
            }
            endIndex++;
        }

        Console.WriteLine("The sequence of maximal sum this array is:");
        StringBuilder maxSequence = new StringBuilder();

        for (int i = seqStart; i <= seqEnd; i++)
        {
            maxSequence.AppendFormat("{0}, ", arrayOfNumbers[i]);
        }

        maxSequence.Length -= 2;
        Console.WriteLine(maxSequence);

    }
}
