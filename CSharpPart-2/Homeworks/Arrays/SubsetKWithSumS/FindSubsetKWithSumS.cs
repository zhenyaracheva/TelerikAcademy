//Problem 17.* Subset K with sum S

//Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
//Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;
using System.Collections.Generic;

class FindSubsetKWithSumS
{
    static List<int[]> solutions = new List<int[]>();

    static void Main()
    {
        Console.Write("Please, enter number N (a length for array): ");
        int n = CheckValidNumber();
        int[] arrayOfNumbers = new int[n];

        Console.WriteLine("Please, enter {0} numbers: ", n);
        for (int i = 0; i < n; i++)
        {
            arrayOfNumbers[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Please, enter number K (subset length): ");
        int k = CheckVAlidK(n);

        Console.Write("Please, enter S (sum you want to find): ");
        int sum = int.Parse(Console.ReadLine());
        int[] combination = new int[k];

        FindCombinations(0, 0, arrayOfNumbers, combination, sum);

        if (solutions.Count ==0)
        {
            Console.WriteLine("No combinations found!");

            
        }
        else if (solutions.Count==1)
        {
            Console.Write("One combination found: ");

            foreach (var solution in solutions)
            {
                for (int i = 0; i < solution.Length; i++)
                {
                    Console.Write("{0} ", solution[i]);
                }

                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Combinations: ");

            foreach (var solution in solutions)
            {
                for (int i = 0; i < solution.Length; i++)
                {
                    Console.Write("{0} ", solution[i]);
                }

                Console.WriteLine();
            }
        }

    }

    private static void FindCombinations(int index, int start, int[] arrayOfNumbers, int[] combination, int sum)
    {
        if (index >= combination.Length)
        {
            int[] saveCombination = new int[3];
            int sumCombination = 0;

            for (int i = 0; i < combination.Length; i++)
            {
                saveCombination[i] = combination[i];
                sumCombination += combination[i];
            }

            if (sumCombination == sum)
            {
                solutions.Add(saveCombination);
            }

            return;
        }
        else
        {
            for (int i = start; i < arrayOfNumbers.Length; i++)
            {
                combination[index] = arrayOfNumbers[i];
                FindCombinations(index + 1, i + 1, arrayOfNumbers, combination, sum);
            }
        }
    }

    private static int CheckVAlidK(int n)
    {
        int number = int.Parse(Console.ReadLine());

        while (number <= 0 || number > n)
        {
            Console.Write("K must be bigger than 1 and smaller than {0}: ", n);
            number = int.Parse(Console.ReadLine());
        }

        return number;
    }

    private static int CheckValidNumber()
    {
        int number = int.Parse(Console.ReadLine());

        while (number <= 0)
        {
            Console.Write("Number must be bigger than 0! Try again: ");
            number = int.Parse(Console.ReadLine());
        }

        return number;
    }
}

