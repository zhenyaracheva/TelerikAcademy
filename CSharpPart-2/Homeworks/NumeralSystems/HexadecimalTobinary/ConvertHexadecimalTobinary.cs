//Problem 5. Hexadecimal to binary

//Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;
using System.Linq;

class ConvertHexadecimalTobinary
{
    static void Main()
    {
        Console.Write("Please, enter hexademical number: ");
        string hex = Console.ReadLine();
        Console.WriteLine("Binary: {0}",Convert.ToString(Convert.ToInt64(hex, 16), 2));
    }
}

