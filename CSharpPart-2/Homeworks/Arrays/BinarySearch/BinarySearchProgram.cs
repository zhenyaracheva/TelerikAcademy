//Problem 11. Binary search

//Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.

using System;

class BinarySearchProgram
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

        int[] arrayOfIntegers = CreateArrayOfIntegers(inputArray);
        Array.Sort(arrayOfIntegers);

        Console.Write("Please, enter number: ");
        int number = int.Parse(Console.ReadLine());
        int index = BinarySearch(arrayOfIntegers, 0, arrayOfIntegers.Length, number);

        if (index == -1)
        {
            Console.WriteLine("Number {0} don't exist in this array!", number);
        }
        else
        {
            Console.WriteLine(index);
        }
    }

    private static int[] CreateArrayOfIntegers(string[] stringArray)
    {
        int[] arrayOfIntegers = new int[stringArray.Length];

        for (int i = 0; i < stringArray.Length; i++)
        {
            arrayOfIntegers[i] = int.Parse(stringArray[i]);
        }

        return arrayOfIntegers;
    }

    public static int BinarySearch(int[] arr, int lowBound, int highBound, int value)
    {
        int mid;
        while (lowBound <= highBound)
        {
            mid = (lowBound + highBound) / 2;

            if (mid < arr.Length)
            {
                if (arr[mid] < value)
                {
                    lowBound = mid + 1;
                    continue;
                }
                else if (arr[mid] > value)
                {
                    highBound = mid - 1;
                    continue;
                }
                else
                {
                    return mid;
                }
            }
            else
            {
                return -1;
            }
        }
        return -1;
    }
}

