//Problem 8. Catalan Numbers

//In combinatorics, the Catalan numbers are calculated by the following formula: catalan-formula
//Write a program to calculate the nth Catalan number by given n (1 <= n <= 100).
//Examples:

//n	    Catalan(n)
//0	    1  ??? n (1 <= n <= 100) !!!!
//5	    42
//10	16796
//15	9694845

using System;

class PrintCatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Please, enter a number /1<=n<=100/:");
        Console.Write("n = ");
        int n = CheckValidN();

        double doubleNFactorial = Factorial(2 * n);
        double nPlusOneFactorial = Factorial(n + 1);
        double NFactorial = Factorial(n);

        Console.WriteLine("Catalan numbers of {0} is {1}", n, (doubleNFactorial / (nPlusOneFactorial * NFactorial)));

    }

    private static int CheckValidN()
    {
        int n = int.Parse(Console.ReadLine());

        while (n < 1 || n > 100)
        {
            Console.WriteLine("Invalid number! K must be bigger than 2 and smaller than 100!");
            Console.Write("Try again: ");
            n = int.Parse(Console.ReadLine());
        }

        return n;
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

