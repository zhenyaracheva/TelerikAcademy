//Problem 5. Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^N

//Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
//Use only one loop. Print the result with 5 digits after the decimal point.
//Examples:

//n	    x	    S
//3	    2	    2.75000
//4	    3	    2.07407
//5	    -4	    0.75781

using System;

class Expression
{
    static void Main()
    {
        Console.Write("Please, enter a positive integer n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please, enter number x: ");
        int x = int.Parse(Console.ReadLine());

        double sum = 1;

        for (int i = 1; i <= n; i++)
        {
            double numFactoriel = Factoriel(i);

            sum += (numFactoriel / Math.Pow(x, i));
        }

        Console.WriteLine("Resylt is: {0:F5}",sum);
    }

    static double Factoriel(int n)
    {
        double result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
}

