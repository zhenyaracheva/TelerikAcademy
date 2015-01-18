//Problem 13.* Comparing Floats

//Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
//Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature 
//of the floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other
//than a fixed constant eps.

using System;
using System.Threading;
using System.Globalization;

class ComparingFloatingPoints
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        string first = Console.ReadLine();
        first = first.Replace(",", ".");
        var firstNumber = Convert.ToDecimal(first);

        string second = Console.ReadLine();
        second = second.Replace(",", ".");
        var secondNumber = Convert.ToDecimal(second);

        decimal esp = 0.000001M;

        if (Math.Abs(firstNumber - secondNumber) < esp)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }

    }
}

