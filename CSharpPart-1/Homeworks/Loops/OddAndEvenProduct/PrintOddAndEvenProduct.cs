//Problem 10. Odd and Even Product

//You are given n integers (given in a single line, separated by a space).
//Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
//Elements are counted from 1 to n, so the first element is odd, the second is even, etc.

using System;

class PrintOddAndEvenProduct
{
    static void Main()
    {
        Console.WriteLine("See whether the product of the odd elements in a line of numbers is equal to the product of the even elements?");
        Console.WriteLine("Please, enter n integers (in a single line, separated by a space).");
        string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        long oddNumbersProduct = 1;
        long evenNumbersProduct = 1;

        for (int i = 1; i <= numbers.Length; i++)
        {
            if (i % 2 == 0)
            {
                evenNumbersProduct *= long.Parse(numbers[i - 1]);
            }
            else
            {
                oddNumbersProduct *= long.Parse(numbers[i - 1]);
            }
        }

        if (oddNumbersProduct == evenNumbersProduct)
        {
            Console.WriteLine("Yes!");
        }
        else
        {
            Console.WriteLine("No!");
        }
    }
}
