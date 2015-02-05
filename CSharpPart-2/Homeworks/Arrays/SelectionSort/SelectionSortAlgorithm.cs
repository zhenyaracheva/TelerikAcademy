//Problem 7. Selection sort

//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
//Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the 
//smallest from the rest, move it at the second position, etc.

using System;

class SelectionSortAlgorithm
{
    static void Main()
    {
        Console.Write("Please, enter an integer lenght for your array:  ");
        int arrayLength = CheckValidInput();


        int[] arrayOfIntegers = new int[arrayLength];

        Console.WriteLine("Please, enter {0} integers", arrayLength);

        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("Array[{0}] = ", i);
            arrayOfIntegers[i] = int.Parse(Console.ReadLine());
        }

        arrayOfIntegers = SelectionSortArray(arrayOfIntegers);
        PrintArray(arrayOfIntegers);

    }

    private static int CheckValidInput()
    {
        int number = int.Parse(Console.ReadLine());

        while (number <= 0)
        {
            Console.Write("Invalid length! Length must be bigger than 0! Try again: ");
            number = int.Parse(Console.ReadLine());
        }

        return number;
    }

    private static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }

        Console.WriteLine();
    }

    private static int[] SelectionSortArray(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }

            int temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }

        return array;
    }
}

