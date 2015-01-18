//Problem 7. Point in a Circle

//Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).
//Examples:

//     x	    y	       inside
//     0	    1	        true
//    -2	    0	        true
//    -1	    2	        false
//    1.5       -1	        true
//    -1.5	   -1.5	        false
//    100	   -30	        false
//    0        	0	        true
//    0.2	   -0.8	        true
//    0.9	   -1.93	    false
//    1	       1.655	    true

using System;

class Circle
{
    static void Main()
    {
        Console.WriteLine("Check if given point (x, y) is inside a circle K({0, 0}, 2)");
        Console.Write("Enter coordinate x: ");
        string firstPoint = Console.ReadLine();
        firstPoint = firstPoint.Replace(",", ".");
        double x = double.Parse(firstPoint);

        Console.Write("Enter coordinate y: ");
        string secondPoint = Console.ReadLine();
        secondPoint = secondPoint.Replace(",", ".");
        double y = double.Parse(secondPoint);

        double radius = 2;
        double result = x * x + y * y;

        

        if (result <= radius * radius)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}

