//Problem 2. Get largest number

//Write a method GetMax() with two parameters that returns the larger of two integers.
//Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

using System;

class PrintLargestNumber
{
    static void Main()
    {
        Console.Write("Please, enter 3 integers (separate by space): ");
        string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int max = int.Parse(numbers[0]);

        for (int i = 1; i < numbers.Length; i++)
        {
            max = GetMax(max, int.Parse(numbers[i])); 
        }

        Console.WriteLine("Max number is {0}", max);
    }
    
    static int GetMax(int first, int second)
    {
        return first > second ? first : second;
    }
}

