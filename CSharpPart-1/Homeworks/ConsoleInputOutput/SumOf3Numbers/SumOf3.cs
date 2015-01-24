//Problem 1. Sum of 3 Numbers

//Write a program that reads 3 real numbers from the console and prints their sum.
//Examples:

// a	b	    c	    sum
// 3 	4	    11	    18
// -2	0	    3	    1
// 5.5	4.5 	20.1	30.1

using System;

class SumOf3
{
    static void Main()
    {
        double result = 0;

        Console.WriteLine("Enter 3 real numbers and see their sum. ");

        for (int i = 1; i <= 3; i++)
        {
            Console.Write("Number {0}: ", i);
            double number = double.Parse(Console.ReadLine());
            result += number;
        }

        Console.WriteLine("Their sum is {0}",result);
    }
}

