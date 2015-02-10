//Problem 13. Solve tasks

//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//Create appropriate methods.

//Provide a simple text-based menu for the user to choose which task to solve.

//Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

using System;
using System.Linq;
using System.Threading;
using System.Globalization;

class Tasks
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Choose which task to solve:");
        Console.WriteLine("Press 1 ----> Reverses the digits of a number!");
        Console.WriteLine("Press 2 ----> Calculates the average of a sequence of integers!");
        Console.WriteLine("Press 3 ----> Solves a linear equation a * x + b = 0!");
        Console.Write("Please, enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Please, enter a positive number: ");
            decimal number = CheckValidNumber();
            Console.WriteLine("Reversed number {0} is {1}", number, ReverseNumber(number));
        }
        else if (choice == 2)
        {
            //TODO:
        }
        else if (choice == 3)
        {
            //TODO:
        }
        else
        {
            throw new ArgumentException("Invalid choice!");
        }
    }

    private static decimal CheckValidNumber()
    {
        string num = Console.ReadLine();
        num = num.Replace(",", ".");

        decimal number = decimal.Parse(num);

        while (number < 0)
        {
            number = decimal.Parse(Console.ReadLine());
        }

        return number;
    }

    private static decimal ReverseNumber(decimal number)
    {
        return decimal.Parse(new string(number.ToString().ToCharArray().Reverse().ToArray()));
    }

    private static double Average(int[] arrayOfNumbers)
    {
        return arrayOfNumbers.Average();
    }

    //private static double SolveLinearEquation(string linearEquation)
    //{
        



    //}
}

