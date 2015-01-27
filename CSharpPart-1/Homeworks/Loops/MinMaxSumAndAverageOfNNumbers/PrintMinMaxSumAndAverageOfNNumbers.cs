//Problem 3. Min, Max, Sum and Average of N Numbers

//Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, 
//the sum and the average of all numbers (displayed with 2 digits after the decimal point).
//The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
//The output is like in the examples below.

using System;

class PrintMinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        Console.Write("Please, enter a positive integer: ");
        int n = int.Parse(Console.ReadLine());

        int min = int.MaxValue;
        int max = int.MinValue;
        int sum = 0;

        if (n > 0)
        {
            if (n == 1)
            {
                Console.WriteLine("Please, enter {0} integer", n);
            }
            else
            {
                Console.WriteLine("Please, enter {0} integers", n);
            }

            for (int i = 1; i <= n; i++)
            {
                Console.Write("Please, enter: ", i);
                int number = int.Parse(Console.ReadLine());

                if (min > number)
                {
                    min = number;
                }

                if (max < number)
                {
                    max = number;
                }

                sum += number;

            }
        }
        else
        {
            min = 0;
            max = 0;
            sum = 0;
        }

        Console.WriteLine("Min = {0}", min);
        Console.WriteLine("Max = {0}", max);
        Console.WriteLine("Sum = {0}", sum);
        Console.WriteLine("Avg = {0:0.00}", (double)sum / n);
    }
}

