//Problem 19.* Permutations of set

//Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
//Example:

//N	     result
//3	    {1, 2, 3} 
//      {1, 3, 2} 
//      {2, 1, 3} 
//      {2, 3, 1} 
//      {3, 1, 2} 
//      {3, 2, 1}

using System;

class PrintPermutationsOfSet
{
    static void Main()
    {

        Console.Write("Please, enter a number: ");
        int n = CheckValidN();
        int[] arrayOfNumbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            arrayOfNumbers[i] = i + 1;
        }

        GeneratePermutations(arrayOfNumbers, 0);

    }

    private static int CheckValidN()
    {
        int n = int.Parse(Console.ReadLine());

        while (n <= 0)
        {
            Console.Write("Number must be bigger tha 0! Try again: ");
            n = int.Parse(Console.ReadLine());
        }

        return n;
    }

    static void GeneratePermutations<T>(T[] arr, int k)
    {
        if (k >= arr.Length)
        {
            Print(arr);
        }
        else
        {
            GeneratePermutations(arr, k + 1);
            for (int i = k + 1; i < arr.Length; i++)
            {
                Swap(ref arr[k], ref arr[i]);
                GeneratePermutations(arr, k + 1);
                Swap(ref arr[k], ref arr[i]);
            }
        }
    }

    static void Print<T>(T[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }

}

