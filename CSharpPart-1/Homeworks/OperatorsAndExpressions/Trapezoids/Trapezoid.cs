//Problem 9. Trapezoids

//Write an expression that calculates trapezoid's area by given sides a and b and height h.
//Examples:

//a	        b	    h	    area
//5	        7	    12	    72
//2	        1	    33	    49.5
//8.5	    4.3	    2.7	    17.28
//100	    200	    300	    45000
//0.222	    0.333	0.555	0.1540125

using System;

class Trapezoid
{
    static void Main()
    {
        Console.Write("Enter side a: ");
        string firstSide = Console.ReadLine();
        firstSide = firstSide.Replace(",", ".");
        double a = double.Parse(firstSide);

        Console.Write("Enter side b: ");
        string secondSide = Console.ReadLine();
        secondSide = secondSide.Replace(",", ".");
        double b = double.Parse(secondSide);

        Console.Write("Enter height: ");
        string h = Console.ReadLine();
        h = h.Replace(",", ".");
        double height = double.Parse(h);

        double area = (((a + b) * height) / 2);

        Console.WriteLine("Trapezoid's area is: {0}", area);

    }
}

