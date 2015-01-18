//Problem 16.** Bit Exchange (Advanced)

//Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
//The first and the second sequence of bits may not overlap.
//Examples:

// 	  n         p	    q	    k	        binary representation of n      	        binary result	                  result
//1140867093	3	    24	    3	    01000100 00000000 01000000 00010101 	01000010 00000000 01000000 00100101	    1107312677
//4294901775	24	    3	    3	    11111111 11111111 00000000 00001111 	11111001 11111111 00000000 00111111	    4194238527
//2369124121	2	    22	    10	    10001101 00110101 11110111 00011001 	01110001 10110101 11111000 11010001	    1907751121
//987654321	    2	    8	    11	                     -	                                     -	                    overlapping :(
//123456789	    26	    0	    7	                     -	                                     -	                    out of range
//33333333333	-1	    0	    33	                     -	                                     -	                    out of range

using System;
using System.Text;

class ExchangeAdvanced
{
    static void Main()
    {
        Console.Write("Enter positive number: ");
        long number = long.Parse(Console.ReadLine());
        CheckNumber(number);

        StringBuilder binary = new StringBuilder(Convert.ToString(number, 2).PadLeft(32, '0'));

        Console.Write("Enter position P: ");
        int positionP = int.Parse(Console.ReadLine());
        ChekPosition(positionP);

        Console.Write("Enter position Q: ");
        int positionQ = int.Parse(Console.ReadLine());
        ChekPosition(positionQ);

        Console.Write("Enter step K: ");
        int stepK = int.Parse(Console.ReadLine());

        int endFirstIndex = positionP + stepK - 1;
        int secondIndex = positionQ + stepK - 1;

        if (endFirstIndex < 32 && endFirstIndex >= 0 && secondIndex < 32 && secondIndex >= 0)
        {
            while (positionP != endFirstIndex + 1)
            {
                ChangeBits(binary, binary.Length - positionP - 1, binary.Length - positionQ - 1);

                positionP++;
                positionQ++;
            }

            long result = Convert.ToUInt32(binary.ToString(), 2);
            if (result > uint.MaxValue)
            {
                Console.WriteLine("Overlapping!");
            }
            else
            {
                Console.WriteLine(Convert.ToUInt32(binary.ToString(), 2));
            }
        }
        else
        {
            Console.WriteLine("Out of range!");
        }
    }


    private static void CheckNumber(long number)
    {
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
        };
    }

    private static void ChekPosition(int position)
    {
        while (position < 0 || position > 31)
        {
            Console.Write("Invalid position P! Position must be in range 0-31! Try again: ");
            position = int.Parse(Console.ReadLine());
        }
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

