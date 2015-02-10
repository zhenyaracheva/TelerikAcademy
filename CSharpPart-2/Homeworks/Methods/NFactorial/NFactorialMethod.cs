//Problem 10. N Factorial

//Write a program to calculate n! for each n in the range [1..100].
//Hint: Implement first a method that multiplies a number represented as array of digits by given integer number

using System;
using System.Linq;
using System.Numerics;

class NFactorialMethod
{
    static void Main()
    {
        Console.Write("Please, enter a number: ");
        int number = int.Parse(Console.ReadLine());
        BigInteger factorial = Factorial(number);
        Console.WriteLine("{0}! = {1}", number, factorial);
    }

    private static BigInteger Factorial(int number)
    {
        BigInteger result = 1;

        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }

        return result;
    }
}

