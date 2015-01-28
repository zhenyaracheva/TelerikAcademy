//Problem 16. Decimal to Hexadecimal Number

//Using loops write a program that converts an integer number to its hexadecimal representation.
//The input is entered as long. The output should be a variable of type string.
//Do not use the built-in .NET functionality.
//Examples:

//decimal	    hexadecimal
//254	        FE
//6883	        1AE3
//338583669684	4ED528CBB4

using System;
using System.Text;

class ConvertDecimalToHexadecimal
{
    static void Main()
    {
        Console.Write("Please, enter an integer number: ");
        long number = long.Parse(Console.ReadLine());

        StringBuilder hex = new StringBuilder();

        while (number > 15)
        {
            ConvertNumber(number % 16, hex);
            number /= 16;
        }

        ConvertNumber(number, hex);
        Console.WriteLine("Its binary representation is: {0}", hex.ToString());
    }

    private static void ConvertNumber(long part, StringBuilder hex)
    {
        switch (part)
        {
            case 10: hex.Insert(0, "A");
                break;
            case 11: hex.Insert(0, "B");
                break;
            case 12: hex.Insert(0, "C");
                break;
            case 13: hex.Insert(0, "D");
                break;
            case 14: hex.Insert(0, "E");
                break;
            case 15: hex.Insert(0, "F");
                break;
            default: hex.Insert(0, part);
                break;
        }
    }
}

