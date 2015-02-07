//Problem 21.* Combinations of set

//Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N].
//Example:

//N	    K	result
//5	    2	{1, 2} 
//          {1, 3} 
//          {1, 4} 
//          {1, 5} 
//          {2, 3} 
//          {2, 4} 
//          {2, 5} 
//          {3, 4} 
//          {3, 5} 
//          {4, 5}

using System;

class PrintCombinationsOfSet
{
    static int n;
    static int k;
    static int[] arrayOfNumbers;
    static int[] arr;

    static void Main()
    {
        Console.Write("Please, enter number N: ");
        n = CheckValidN();
        arrayOfNumbers = new int[n];

        Console.Write("Please, enter number K: ");
        k = CheckValidK();
        arr = new int[k];

        GenerateCombinations(0, 0);
    }

    static void GenerateCombinations(int index, int start)
    {
        if (index >= k)
        {
            PrintVariations();
        }
        else
        {
            for (int i = start; i < n; i++)
            {
                arr[index] = i+1;
                GenerateCombinations(index + 1, i + 1);
            }
        }
    }

    static void PrintVariations()
    {
        Console.WriteLine("{" + String.Join(", ", arr) + "}");
       
    }
    private static int CheckValidK()
    {
        int k = int.Parse(Console.ReadLine());

        while (k <= 0 || k > n)
        {
            Console.Write("K must be bigger than 0 and smaler than {0}!", n);
            k = int.Parse(Console.ReadLine());
        }

        return k;
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
}

