//Problem 14. Quick sort

//Write a program that sorts an array of strings using the Quick sort algorithm.

using System;

class QuickSortAlgorithm
{
    static int[] arrayOfNumbers;

    static void Main()
    {
        Console.WriteLine("Please, enter numbers of array (separated by space or \",\"): ");
        string[] inputArray = CheckIsValidInput();
        arrayOfNumbers = CreateArray(inputArray);

        QuickSortRecursive(arrayOfNumbers, 0, arrayOfNumbers.Length - 1);

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            Console.Write("{0} ", arrayOfNumbers[i]);
        }

        Console.WriteLine();
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

    static public int Partition(int[] numbers, int left, int right)
    {
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                {
                    left++;
                }

                while (numbers[right] > pivot)
                {
                    right--;
                }

                if (numbers[right] == pivot && numbers[left] == pivot)
                {
                    left++;
                }

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }

    static public void QuickSortRecursive(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            if (pivot > 1)
            {
                QuickSortRecursive(arr, left, pivot - 1);
            }

            if (pivot + 1 < right)
            {
                QuickSortRecursive(arr, pivot + 1, right);
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
}

