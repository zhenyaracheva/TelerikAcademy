//Problem 11.* Numbers in Interval Dividable by Given Number

//Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder 
//of the division by 5 is 0.

using System;
using System.Text;

class NumbersInInterval
{
    static void Main()
    {
        Console.WriteLine("Enter two positive integers and see how many numbers between them after division by 5 has reminder 0");
        Console.Write("Start number: ");
        int start = int.Parse(Console.ReadLine());

        Console.Write("End number: ");
        int end = int.Parse(Console.ReadLine());

        StringBuilder result = new StringBuilder();

        int counter = 0;

        for (int i = start; i <= end; i++)
        {
            if (i % 5 == 0)
            {
                result.AppendFormat("{0}, ", i);
                counter++;
            }
        }

        Console.WriteLine("Numbers divided by 5 with reminder 0: " + counter);

        if (counter > 1)
        {
            result.Length -= 2;
            Console.WriteLine("Numbers are: " + result.ToString());
        }
        else if (counter == 0)
        {
            Console.WriteLine("-");
        }
        else
        {
            result.Length -= 2;
            Console.WriteLine("Number is: " + result.ToString());
        }
    }
}

