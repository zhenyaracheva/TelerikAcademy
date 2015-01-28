//Problem 14. Decimal to Binary Number

//Using loops write a program that converts an integer number to its binary representation.
//The input is entered as long. The output should be a variable of type string.
//Do not use the built-in .NET functionality.

using System;
using System.Text;

class DecimalToBinary
{
    static void Main()
    {
        Console.Write("Please, enter an integer number: ");
        long number = long.Parse(Console.ReadLine());
        StringBuilder binary = new StringBuilder();

        while (number > 1)
        {
            binary.Insert(0, number % 2);
            number /= 2;
        }

        binary.Insert(0, number % 2);
        Console.WriteLine("Its binary representation is: {0}", binary.ToString());
    }
}

