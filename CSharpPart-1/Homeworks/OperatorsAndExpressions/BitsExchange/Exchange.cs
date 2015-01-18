﻿//Problem 15.* Bits Exchange

//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
//Examples:

//    n	            binary representation of n	                 binary result	                  result
//1140867093	01000100 00000000 01000000 00010101	    01000010 00000000 01000000 00100101	    1107312677
//255406592	    00001111 00111001 00110010 00000000	    00001000 00111001 00110010 00111000	    137966136
//4294901775	11111111 11111111 00000000 00001111	    11111001 11111111 00000000 00111111	    4194238527
//5351	        00000000 00000000 00010100 11100111	    00000100 00000000 00010100 11000111	    67114183
//2369124121	10001101 00110101 11110111 00011001	    10001011 00110101 11110111 00101001     2335569705

using System;
using System.Text;

class Exchange
{
    static void Main()
    {
        Console.Write("Enter positive number: ");
        long number = long.Parse(Console.ReadLine());

        while (number < 0 || number > uint.MaxValue)
        {
            if (number > uint.MaxValue)
            {
                Console.Write("Number is too long! Try again: ");
                number = long.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("Number must be positive! Try again: ");
                number = long.Parse(Console.ReadLine());
            }
        }

        StringBuilder binary = new StringBuilder(Convert.ToString(number, 2).PadLeft(32, '0'));
        ChangeBits(binary, binary.Length - 3 - 1, binary.Length - 24 - 1);
        ChangeBits(binary, binary.Length - 4 - 1, binary.Length - 25 - 1);
        ChangeBits(binary, binary.Length - 5 - 1, binary.Length - 26 - 1);

        Console.WriteLine("Number after exchanging bits: {0}", Convert.ToUInt32(binary.ToString(), 2));
    }

    public static void ChangeBits(StringBuilder binary, int firstBit, int secondBit)
    {
        if (binary[firstBit] != binary[secondBit])
        {
            char temp = binary[firstBit];
            binary[firstBit] = binary[secondBit];
            binary[secondBit] = temp;
        }
    }


}
