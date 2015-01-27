//Problem 9. Matrix of Numbers

//Write a program that reads from the console a positive integer number n (1 = n = 20) and prints a matrix like in the 
//examples below. Use two nested loops.
//Examples:

//n = 2   matrix      n = 3   matrix      n = 4   matrix
//        1 2                 1 2 3               1 2 3 4
//        2 3                 2 3 4               2 3 4 5
//                            3 4 5               3 4 5 6
//                                                4 5 6 7

using System;

class PrintMatrix
{
    static void Main()
    {
        Console.Write("Please, enter a positive number: ");
        int number = CheckVAlidNumber();

        for (int i = 1; i <= number; i++)
        {
            for (int j = i; j < number + i; j++)
            {
                Console.Write("{0} ", j);
            }
            Console.WriteLine();
        }
    }

    private static int CheckVAlidNumber()
    {
        int n = int.Parse(Console.ReadLine());

        while (n <= 0)
        {
            Console.Write("Invalid number! Number must be positive! Try again: ");
            n = int.Parse(Console.ReadLine());
        }

        return n;
    }
}

