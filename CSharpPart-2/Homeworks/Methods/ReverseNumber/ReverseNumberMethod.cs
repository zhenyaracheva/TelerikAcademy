//Problem 7. Reverse number

//Write a method that reverses the digits of given decimal number.

using System;
using System.Linq;

class ReverseNumberMethod
{
    static void Main()
    {
        Console.Write("Please, enter a number(integer or decimal): ");
        decimal number = decimal.Parse(Console.ReadLine());
        decimal reversed = ReverseNumber(number);
        Console.WriteLine("Reversed number is {0}", reversed);
    }

    private static decimal ReverseNumber(decimal number)
    {
        return decimal.Parse(new string(number.ToString().ToCharArray().Reverse().ToArray()));
    }
}

