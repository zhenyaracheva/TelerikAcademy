//Problem 9.* Binary floating-point

//Write a program that shows the internal binary representation of given 32-bit signed 
//floating-point number in IEEE 754 format (the C# type float).
//Example:

//number	sign	exponent	            mantissa
//-27,25	  1	    10000011	     10110100000000000000000

using System;
using System.Linq;

class PrintBinaryFloatingPoint
{
    static void Main()
    {
        Console.Write("Please, enter a floating-point number: ");
        float number = float.Parse(Console.ReadLine());
        string binary = ConvertFloatingPointToBynary(number);
        Console.WriteLine("Binary: {0}", binary);
        Console.WriteLine("Sign: {0}", binary[0]);
        Console.WriteLine("Exponent: {0}", binary.Substring(1, 8));
        Console.WriteLine("Mantissa: {0}", binary.Substring(9, binary.Length - 9));
    }

    private static string ConvertFloatingPointToBynary(float number)
    {
        char sign = number < 0 ? '1' : '0';

        if (number == 0)
        {
            return Convert.ToString(0, 2).PadLeft(32, '0');
        }
        else if (number < 0)
        {
            number = number * (-1);
        }

        int temp = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
        return sign + Convert.ToString(temp, 2);
    }
}
