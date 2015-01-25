//Problem 5. The Biggest of 3 Numbers

//Write a program that finds the biggest of three numbers.
//Examples:

//a 	b	     c	    biggest
//5 	2	     2	     5
//-2	-2	     1	     1
//-2	4	     3	     4
//0	    -2.5	 5	     5
//-0.1	-0.5	-1.1	-0.1

using System;

class TheBiggestOf3
{
    static void Main()
    {
        Console.WriteLine("Enter 3 numbers.");
        double max = double.MinValue;

        for (int i = 1; i <= 3; i++)
        {
            Console.Write("Enter number {0}: ", i);
            double number = double.Parse(Console.ReadLine());

            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine("The biggest number is " + max);
    }
}

