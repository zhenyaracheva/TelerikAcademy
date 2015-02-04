//Problem 2. Compare arrays

//Write a program that reads two integer arrays from the console and compares them element by element.

using System;

class CompareTwoArrays
{
    static void Main()
    {
        Console.Write("Please, enter the lenght of the first array: ");
        int firstArrayLenght = int.Parse(Console.ReadLine());
        int[] array1 = new int[firstArrayLenght];

        for (int i = 0; i < firstArrayLenght; i++)
        {
            Console.Write("Array1[{0}] = ", i);
            array1[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Please, enter the lenght of the second array: ");
        int secondArrayLenght = int.Parse(Console.ReadLine());
        int[] array2 = new int[secondArrayLenght];

        for (int i = 0; i < secondArrayLenght; i++)
        {
            Console.Write("Array2[{0}] = ", i);
            array2[i] = int.Parse(Console.ReadLine());
        }

        if (array1.Length == array2.Length)
        {

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    Console.WriteLine("Not equal!");
                    return;
                }
            }

            Console.WriteLine("Equal!");
        }
        else
        {
            Console.WriteLine("Not equal!");
        }
    }
}

