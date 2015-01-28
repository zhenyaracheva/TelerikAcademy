//Problem 15. Hexadecimal to Decimal Number

//Using loops write a program that converts a hexadecimal integer number to its decimal form.
//The input is entered as string. The output should be a variable of type long.
//Do not use the built-in .NET functionality.
//Examples:

//hexadecimal	decimal
//FE	        254
//1AE3	        6883
//4ED528CBB4	338583669684

using System;
using System.Collections.Generic;

class ConvertHexadecimalToDecimal
{
    static void Main()
    {
        Console.Write("Please, enter  a hexadecimal integer number: ");
        string hex = Console.ReadLine();
        long decimalNumber = 0;

        for (int i = 0; i < hex.Length; i++)
        {
            long currentIndex = ConvetNumber(hex[i]);

            decimalNumber += (long)Math.Pow(16, hex.Length - 1 - i)* currentIndex;

        }

        Console.WriteLine(decimalNumber);
    }

    private static long ConvetNumber(char num)
    {
        switch (num)
        {
            case 'A': return 10;
            case 'B': return 11;
            case 'C': return 12;
            case 'D': return 13;
            case 'E': return 14;
            case 'F': return 15;
            default: return long.Parse(num.ToString());
        }
    }
}

