//Problem 7. Sort 3 Numbers with Nested Ifs

//Write a program that enters 3 real numbers and prints them sorted in descending order.
//Use nested if statements.
//Note: Don’t use arrays and the built-in sorting functionality.

//Examples:

//a	    b	    c	        result
//5	    1	    2	    5     2     1
//-2	-2	    1	    1     -2   -2
//-2	4	    3	    4     3    -2
//0	    -2.5	5	    5     0    -2.5
//-1.1	-0.5	-0.1	-0.1  -0.5 -1.1
//10	20	    30	    30    20    10
//1	    1	    1	    1     1     1

using System;
using System.Text;

class Sort3Numbers
{
    static void Main()
    {
        Console.WriteLine("Enters 3 real numbers see them sorted in descending order.");

        Console.Write("Enter first number: ");
        double first = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double second = double.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        double third = double.Parse(Console.ReadLine());

        StringBuilder result = new StringBuilder();

        if (first >= second && first >= third)
        {
            result.AppendFormat("{0} ", first);

            if (second > third)
            {
                result.AppendFormat("{0} {1}", second, third);
            }
            else
            {
                result.AppendFormat("{0} {1}", third, second);
            }
        }
        else if (second >= first && second >= third)
        {
            result.AppendFormat("{0} ", second);

            if (first > third)
            {
                result.AppendFormat("{0} {1}", first, third);
            }
            else
            {
                result.AppendFormat("{0} {1}", third, first);
            }
        }
        else if (third >= first && third >= second)
        {
            result.AppendFormat("{0} ", third);

            if (first > second)
            {
                result.AppendFormat("{0} {1}", first, second);
            }
            else
            {
                result.AppendFormat("{0} {1}", second, first);
            }
        }

        Console.WriteLine("Sorted numbers in descending order: " + result.ToString());
    }
}

