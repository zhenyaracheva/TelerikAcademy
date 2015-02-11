//Problem 1. Decimal to binary

//Write a program to convert decimal numbers to their binary representation.

using System;
using System.Linq;

class ConvertDecimalToBinary
{
    static void Main()
    {
        Console.Write("Please, enter number: ");
        long num = long.Parse(Console.ReadLine());
        string binary = Convert.ToString(num, 2);
        Console.WriteLine(binary);
    }
}

