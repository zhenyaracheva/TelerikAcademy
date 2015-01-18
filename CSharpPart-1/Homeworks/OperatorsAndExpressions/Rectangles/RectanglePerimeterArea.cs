//Problem 4. Rectangles

//Write an expression that calculates rectangle’s perimeter and area by given width and height.
//Examples:

//width	height	perimeter	area
//3	      4 	    14	     12
//2.5	  3	        11	     7.5
//5	      5	        20	     25

using System;

class RectanglePerimeterArea
{
    static void Main()
    {
        Console.Write("Enter rectangle width: ");
        string firstNumber = Console.ReadLine();
        firstNumber = firstNumber.Replace(",", ".");
        double width = double.Parse(firstNumber);

        Console.Write("Enter rectangle height: ");
        string secondNumber = Console.ReadLine();
        secondNumber = secondNumber.Replace(",", ".");
        double height = double.Parse(secondNumber);

        Console.WriteLine("The perimeter of this rectangle is: {0}", 2 * width + 2 * height);

        Console.WriteLine("The area of this rectangle is: {0}", width * height);
    }
}

