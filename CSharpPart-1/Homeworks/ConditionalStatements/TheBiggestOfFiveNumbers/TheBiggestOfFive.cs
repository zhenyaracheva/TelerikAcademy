//Problem 6. The Biggest of Five Numbers

//Write a program that finds the biggest of five numbers by using only five if statements.
//Examples:

//a	    b	     c	    d	  e	    biggest
//5	    2	     2	    4	  1	     5
//-2	-22	     1	    0	  0	     1
//-2	4	     3	    2	  0	     4
//0	    -2.5	 0	    5	  5	     5
//-3	-0.5	-1.1	-2	-0.1	-0.1

using System;

class TheBiggestOfFive
{
    static void Main()
    {
        Console.WriteLine("Enter 5 number and find the biggest.");
        double max = double.MinValue;

        for (int i = 1; i <= 5; i++)
        {
            Console.Write("Enter number {0}: ", i);
            double number = double.Parse(Console.ReadLine());

            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine("The biggest number is {0}", max);
    }
}

