//Problem 6. Quadratic Equation

//Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
//Examples:

//a	    b	 c	    roots
//2	    5	 -3	    x1=-3; x2=0.5
//-1	3	 0	    x1=3; x2=0
//-0.5	4	 -8	    x1=x2=4
//5	    2	 8	    no real roots

using System;

class Quadratic
{
    static void Main()
    {
        Console.WriteLine("Enter coefficients a, b and c of a quadratic equation ax2 + bx + c = 0:");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        double D = (b * b) - (4 * a * c);

        double x1;

        if (D > 0)
        {
            x1 = ((-1) * b - Math.Sqrt(D)) / (2 * a);
            double x2 = ((-1) * b + Math.Sqrt(D)) / (2 * a); ;
            Console.WriteLine("x1 = {0}; x2 = {1}", x1, x2);
        }
        else if (D == 0)
        {
            x1 = -b / (2 * a);
            Console.WriteLine("x1 = x2 = {0}", x1);
        }
        else
        {
            Console.WriteLine("no real roots");
        }
    }
}

