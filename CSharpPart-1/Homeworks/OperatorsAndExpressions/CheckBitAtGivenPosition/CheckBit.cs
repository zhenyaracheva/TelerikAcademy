//Problem 13. Check a Bit at Given Position

//Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n,
//has value of 1.
//Examples:

//n	    binary representation of n	    p	bit @ p == 1
//5	        00000000 00000101	        2	    true   
//0	        00000000 00000000	        9	    false  
//15	    00000000 00001111	        1	    true   
//5343	    00010100 11011111	        7	    true   
//62241	    11110011 00100001	        11	    false

using System;

class CheckBit
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        string binary = Convert.ToString(number, 2).PadLeft(16, '0');

        Console.Write("Enter position: ");
        int position = int.Parse(Console.ReadLine());

        Console.Write("Has the bit at position {0} in given integer {1}  value of 1? ",position, number);

        if (binary[binary.Length-position-1]=='1')
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}

