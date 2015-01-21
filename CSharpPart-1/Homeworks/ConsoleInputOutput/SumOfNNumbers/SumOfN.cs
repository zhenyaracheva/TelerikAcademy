//Problem 9. Sum of n Numbers

//Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum. 
//Note: You may need to use a for-loop.

using System;

class SumOfN
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int n = FindNumber();
        double sum = 0;

        for (int i = 1; i <= n; i++)
        {
            Console.Write("Number {0} is: ", i);
            sum += double.Parse(Console.ReadLine());
        }

        Console.WriteLine("Their sum is {0}", sum);
    }

    private static int FindNumber()
    {
        int number = int.Parse(Console.ReadLine());

        while (number < 0)
        {
            Console.Write("Invalid number!Number must be positive! Try again: ");
            number = int.Parse(Console.ReadLine());
        }

        return number;
    }
}

