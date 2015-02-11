//Problem 4. Hexadecimal to decimal

//Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class ConvertHexadecimalToDecimal
{
    static void Main()
    {
        Console.Write("Please, enter a hexademical number: ");
        string hex = Console.ReadLine();
        Console.WriteLine(Convert.ToInt64(hex, 16));

    }
}