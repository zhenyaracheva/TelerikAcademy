//Problem 10. Point Inside a Circle & Outside of a Rectangle

//Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle 
//R(top=1, left=-1, width=6, height=2).
//Examples:

//x	        y	    inside K & outside of R
//1	        2	            yes 
//2.5	    2	            no  
//0	        1	            no  
//2.5	    1	            no  
//2	        0	            no  
//4	        0	            no  
//2.5	    1.5	            no  
//2	        1.5	            yes 
//1	        2.5	            yes 
//-100	    -100	        no  

using System;

class InsideCircleOutsideRectangle
{
    static void Main()
    {
        Console.WriteLine("Check for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2)");
        Console.Write("Enter coordinate x: ");
        string firstPoint = Console.ReadLine();
        firstPoint = firstPoint.Replace(",", ".");
        double x = double.Parse(firstPoint);

        Console.Write("Enter coordinate y: ");
        string secondPoint = Console.ReadLine();
        secondPoint = secondPoint.Replace(",", ".");
        double y = double.Parse(secondPoint);

        bool isInCircle = CheckIfPointIsInCircle(x, y);
        bool isInRectangle = CheckIfPointIsInRectangle(x, y);

        if (isInCircle && !isInRectangle)
        {
            Console.WriteLine("Yes!");
        }
        else
        {
            Console.WriteLine("No!");
        }
    }

    private static bool CheckIfPointIsInRectangle(double x, double y)
    {
        if (x >= -1 && x <= 5 && y >= -1 && y <= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool CheckIfPointIsInCircle(double x, double y)
    {
        double radius = 1.5;
        double result = (1 - x) * (1 - x) + (1 - y) * (1 - y);

        if (result <= radius * radius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

