//Problem 14. Modify a Bit at Given Position

//We are given an integer number n, a bit value v (v=0 or 1) and a position p.
//Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position p from the binary representation of n while preserving all other bits in n.
//Examples:

//n	        binary representation of n	  p	    v	  binary result	    result
//5	             00000000 00000101	      2	    0	00000000 00000001	 1
//0	             00000000 00000000	      9	    1	00000010 00000000	 512
//15	         00000000 00001111	      1	    1	00000000 00001111	 15
//5343	         00010100 11011111	      7	    0	00010100 01011111	 5215
//62241	         11110011 00100001	      11	0	11110011 00100001	 62241

using System;
using System.Text;

class ModifyBit
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        StringBuilder binary = new StringBuilder(Convert.ToString(number, 2).PadLeft(16, '0'));

        Console.Write("Enter bit value (0 or 1): ");
        char bit = char.Parse(Console.ReadLine());

        while (bit != '0' && bit != '1')
        {
            Console.Write("Wrong bit value! Try again: ");
            bit = char.Parse(Console.ReadLine());
        }

        Console.Write("Enter bit position: ");
        int position = int.Parse(Console.ReadLine());

        while (position >= 16)
        {
            Console.Write("Invalid bit position! Try again: ");
            position = int.Parse(Console.ReadLine());
        }

        binary[binary.Length - position - 1] = bit;

        Console.WriteLine(Convert.ToInt32(binary.ToString(), 2));
    }
}

