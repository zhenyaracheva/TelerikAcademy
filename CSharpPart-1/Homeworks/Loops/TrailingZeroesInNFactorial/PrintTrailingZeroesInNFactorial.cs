//Problem 18.* Trailing Zeroes in N!

//Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
//Your program should work well for very big numbers, e.g. n=100000.
//Examples:

//n	        trailing zeroes of n!	explaination
//10	    2	                    3628800
//20	    4	                    2432902008176640000
//100000	24999	                think why

using System;
using System.Numerics;

class PrintTrailingZeroesInNFactorial
{
    static void Main()
    {
        Console.Write("Please, enter a number: ");
        int number = int.Parse(Console.ReadLine());
        BigInteger factorialNumber = Factorial(number);
        int counter = 0;

        for (int i = factorialNumber.ToString().Length - 1; i >= 0; i--)
        {
            if (factorialNumber.ToString()[i] == '0')
            {
                counter++;
            }
            else
            {
                Console.WriteLine(counter);
                break;
            }
        }
    }

    static BigInteger Factorial(int n)
    {
        BigInteger result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
}