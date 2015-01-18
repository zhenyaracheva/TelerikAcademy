//Problem 1. Odd or Even Integers

//Write an expression that checks if given integer is odd or even.
//Examples:

//n	Odd?
//3	true
//2	false
//-2	false
//-1	true
//0	false

using System;

class OddOrEven
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        bool isOdd = false;

        if (number % 2 == 1)
        {
            isOdd = true;
        }

        Console.WriteLine("Is number {0} odd? {1}", number, isOdd);
    }
}

