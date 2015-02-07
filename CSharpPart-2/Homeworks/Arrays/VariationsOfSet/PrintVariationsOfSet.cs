//Problem 20.* Variations of set

//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].
//Example:

//N	    K	result
//3	    2	{1, 1} 
//          {1, 2} 
//          {1, 3} 
//          {2, 1} 
//          {2, 2} 
//          {2, 3} 
//          {3, 1} 
//          {3, 2} 
//          {3, 3}

using System;

class PrintVariationsOfSet
{
    static int n;
    static int k;
    static int[] arrayOfNumbers;
    static int[] arr;
    static bool[] used;

    static void Main()
    {
        Console.Write("Please, enter number N: ");
        n = CheckValidN();
        arrayOfNumbers = new int[n];
        used = new bool[n];

        Console.Write("Please, enter number K: ");
        k = CheckValidK();
        arr = new int[k];


        GenerateVariations(0);
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

    static void GenerateVariations(int index)
    {
        if (index >= k)
        {
            PrintVariations();
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                arr[index] = i+1;
                GenerateVariations(index + 1);
            }
        }
    }

    static void PrintVariations()
    {
        Console.WriteLine("{" + String.Join(", ", arr) + "}");
    }

}

