//Problem 6. Maximal K sum

//Write a program that reads two integer numbers N and K and an array of N elements from the console.
//Find in the array those K elements that have maximal sum.

using System;
using System.Collections.Generic;
using System.Text;

class PrintMaximalKSum
{
    static void Main()
    {
        Console.Write("Please, enter number N: ");
        int n = int.Parse(Console.ReadLine());

        if (n <= 0)
        {
            while (n <= 0)
            {
                Console.Write("Invalid number! N must be bigger than 0! Try again: ");
                n = int.Parse(Console.ReadLine());
            }
        }

        int[] array = new int[n];

        Console.WriteLine("Please, enter {0} numbers:", n);
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());

        }

        Console.Write("Please, enter number K: ");
        int k = int.Parse(Console.ReadLine());

        if (k > n || k <= 0)
        {
            while (k >= n || k <= 0)
            {
                Console.Write("Invalid number! K must be in range: 0 < K <= N! Try again: ");
                k = int.Parse(Console.ReadLine());
            }
        }

        Array.Sort(array);
        Array.Reverse(array);
        List<string> solutions = new List<string>();

        int maxSum = int.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            StringBuilder result = new StringBuilder();
            int sum = 0;

            for (int j = i; j < k + i; j++)
            {
                sum += array[j];
                result.AppendFormat("{0}, ", array[j]);
            }

            if (maxSum < sum)
            {
                maxSum = sum;
                result.Length -= 2;
                solutions.Add(result.ToString());
            }
            else if (maxSum == sum)
            {
                result.Length -= 2;
                solutions.Add(result.ToString());
            }
            else
            {
                break;
            }
        }

        foreach (var solution in solutions)
        {
            Console.WriteLine(solution);
        }
    }
}

