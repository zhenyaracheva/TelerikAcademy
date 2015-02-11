//Problem 3. Decimal to hexadecimal

//Write a program to convert decimal numbers to their hexadecimal representation

using System;
using System.Linq;
class ConvertDecimalToHexadecimal
{
    static void Main()
    {
        Console.Write("Please, enter number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Hexadecimal representation: {0}",number.ToString("X"));
    }
}

