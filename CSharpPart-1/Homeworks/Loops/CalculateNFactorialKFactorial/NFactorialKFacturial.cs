//Problem 6. Calculate N! / K!

//Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
//Use only one loop.
//Examples:

//n	    k	n! / k!
//5	    2	  60
//6	    5	  6
//8	    3	  6720

using System;

class NFactorialKFacturial
{
    static void Main()
    {

        Console.WriteLine("Please, enter numbers n and k (1 < k < n < 100)");
        Console.Write("n = ");
        int n = CheckValidN();
        Console.Write("k = ");
        int k = CheckValidK(n);

        Console.WriteLine("{0} ", Factorial(n) / Factorial(k));

    }
    private static int CheckValidN()
    {
        int n = int.Parse(Console.ReadLine());

        while (n < 2 || n > 99)
        {
            Console.WriteLine("Invalid number! K must be bigger than 2 and smaller than 100!");
            Console.Write("Try again: ");
            n = int.Parse(Console.ReadLine());
        }

        return n;
    }

    private static int CheckValidK(int n)
    {
        int k = int.Parse(Console.ReadLine());

        while (k < 1 || n < k)
        {
            Console.WriteLine("Invalid number! K must be bigger than 1 and smaller than n!");
            Console.Write("Try again: ");
            k = int.Parse(Console.ReadLine());
        }

        return k;
    }

    static double Factorial(int n)
    {
        double result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
}

