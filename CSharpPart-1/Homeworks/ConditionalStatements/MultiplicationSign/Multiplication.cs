//Problem 4. Multiplication Sign

//Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
//Use a sequence of if operators.
//Examples:

//a	     b	     c	    result
//5	     2	     2	      +
//-2	-2	     1	      +
//-2	 4	     3	      -
//0	    -2.5	 4	      0
//-1	-0.5	-5.1	  -

using System;

class Multiplication
{
    static void Main()
    {
        Console.WriteLine("See the sign (+, - or 0) of the product of three real numbers.");

        int minusCount = 0;
        bool isZero = false;

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter number: ");
            double number = double.Parse(Console.ReadLine());

            if (number < 0)
            {
                minusCount++;
            }
            else if (number == 0)
            {
                isZero = true;
            }
        }

        Console.Write("The sign is: ");

        if (!isZero)
        {
            if (minusCount % 2 == 1)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine("+");
            }
        }
        else
        {
            Console.WriteLine("0");
        }

    }
}

