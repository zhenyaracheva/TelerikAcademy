//Problem 4. Appearance count

//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is workings correctly.

using System;

class AppearanceCountMethod
{
    static void Main()
    {
        Console.WriteLine("Please, enter an array of integers (separate by space):");
        string[] arrayOfStrings = CheckArray();
        int[] arrayOfNumbers = ConvertArrayToInt(arrayOfStrings);

        Console.Write("Please, enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int foundNumber = FoundNumberCountInArray(arrayOfNumbers, number);

        Console.WriteLine("Number {0} appears {1} times in this array.", number, foundNumber);
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

    private static int FoundNumberCountInArray(int[] arrayOfNumbers, int number)
    {
        int counter = 0;

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            if (arrayOfNumbers[i] == number)
            {
                counter++;
            }
        }

        return counter;
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

