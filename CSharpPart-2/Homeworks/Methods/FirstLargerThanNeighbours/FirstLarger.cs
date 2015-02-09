//Problem 6. First larger than neighbours

//Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
//Use the method from the previous exercise.

using System;

class FirstLarger
{
    static void Main()
    {
        Console.WriteLine("Please, enter an array of integers (separate by space):");
        string[] arrayOfStrings = CheckArray();
        int[] arrayOfNumbers = ConvertArrayToInt(arrayOfStrings);

        int firstLarger = FirstLargerNeightbour(arrayOfNumbers);

        Console.WriteLine(firstLarger);
    }

    private static int FirstLargerNeightbour(int[] arrayOfNumbers)
    {
        if (arrayOfNumbers[0]>arrayOfNumbers[1])
        {
            return 0;
        }
        else
        {
            for (int i = 1; i < arrayOfNumbers.Length - 1; i++)
            {
                if ((arrayOfNumbers[i] > arrayOfNumbers[i-1]) && arrayOfNumbers[i]>arrayOfNumbers[i+1])
                {
                    return i;
                }
            }

            if (arrayOfNumbers[arrayOfNumbers.Length-1]>arrayOfNumbers[arrayOfNumbers.Length-2])
            {
                return arrayOfNumbers.Length - 1;
            }
        }

        return -1;
    }

    private static int[] ConvertArrayToInt(string[] arrayOfStrings)
    {
        int[] arrayOfNumbers = new int[arrayOfStrings.Length];

        for (int i = 0; i < arrayOfStrings.Length; i++)
        {
            arrayOfNumbers[i] = int.Parse(arrayOfStrings[i]);
        }

        return arrayOfNumbers;
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

