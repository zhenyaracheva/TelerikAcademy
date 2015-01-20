//Problem 3. Circle Perimeter and Area

//Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.
//Examples:

//r	    perimeter	area
//2	    12.57	    12.57
//3.5	21.99	    38.48

using System;

class CirclePerimeterArea
{
    static void Main()
    {
        Console.Write("Enter circle radius: ");
        double r = double.Parse(Console.ReadLine());

        Console.WriteLine("Circle perimeter is {0:0.00}", 2 * r * Math.PI);
        Console.WriteLine("Circle area is {0:0.00}", Math.PI * r * r);

    }
}

