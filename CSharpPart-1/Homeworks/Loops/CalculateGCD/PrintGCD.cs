//Problem 17.* Calculate GCD

//Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
//Use the Euclidean algorithm (find it in Internet).
//Examples:

//a	    b	    GCD(a, b)
//3	    2	    1
//60	40	    20
//5 	-15	    5

using System;

class PrintGCD
{
    static void Main()
    {
        Console.Write("Please, enter first number: ");
        int a = int.Parse(Console.ReadLine());
        if (a < 0)
        {
            a *= (-1);
        }

        Console.Write("Please, enter second number: ");
        int b = int.Parse(Console.ReadLine());
        if (b < 0)
        {
            b *= (-1);
        }

        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        if (a == 0)
        {
            Console.WriteLine(b);
        }

        else
        {
            Console.WriteLine(a);
        }
    }
}

