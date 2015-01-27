//Problem 7. Calculate N! / (K! * (N-K)!)

//In combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number 
//of combinations) is calculated by the following formula: formula For example, there are 2598960 ways to withdraw 5 cards out of a 
//standard deck of 52 cards.
//Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops.
//Examples:

//n	    k	n! / (k! * (n-k)!)
//3	    2	        3
//4	    2	        6
//10	6	        210
//52	5	        2598960

using System;

class FactorialExpression
{
    static void Main()
    {

        Console.WriteLine("Please, enter numbers n and k (1 < k < n < 100)");
        Console.Write("n = ");
        int n = CheckValidN();
        Console.Write("k = ");
        int k = CheckValidK(n);

        double NFactorial = Factorial(n);
        double KFactorial = Factorial(k);
        double NMinusKFactorial = Factorial(n - k);

        Console.WriteLine(NFactorial / (KFactorial * NMinusKFactorial));

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

