//Problem 11. Format number

//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
//Format the output aligned right in 15 symbols.

using System;

class PrintFormatNumber
{
    static void Main()
    {
        Console.Write("Please, enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("{0,15:D} --> Decimal;", number);
        Console.WriteLine("{0,15:X} --> Hexadecimal;", number);
        Console.WriteLine("{0,15:P} --> Percentage;", number);
        Console.WriteLine("{0,15:E} --> Scientific notation.", number);
    }
}

