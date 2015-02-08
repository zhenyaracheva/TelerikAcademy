//Problem 4. Binary search

//Write a program, that reads from the console an array of N integers and an integer K, 
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.

using System;

class BinarySearchTask
{
    static void Main()
    {
        Console.WriteLine("Please, enter an array of numbers (numbers must be separate by space):");
        string[] numbersAsStrings = CheckArray();
        int[] numbers = ConvertArrayToInt(numbersAsStrings);

        Console.Write("Please, enter an integer K: ");
        int k = int.Parse(Console.ReadLine());
        Array.Sort(numbers);

        Console.Write("The largest number in the array which is ≤ {0} is ", k);

        while (Array.BinarySearch(numbers, k) < 0)
        {
            k--;
        }

        Console.WriteLine(k);
    }

    private static int[] ConvertArrayToInt(string[] stringArray)
    {
        int[] arrayOfNumbers = new int[stringArray.Length];

        for (int i = 0; i < stringArray.Length; i++)
        {
            arrayOfNumbers[i] = int.Parse(stringArray[i]);
        }

        return arrayOfNumbers;
    }

    private static string[] CheckArray()
    {
        string[] line = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        while (line.Length <= 0)
        {
            Console.Write("Array length must be bigger than 0! Try again: ");
            line = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return line;
    }
}
