//Problem 3. Compare char arrays

//Write a program that compares two char arrays lexicographically (letter by letter).

using System;
using System.Linq;

class CompareTwoCharArrays
{
    static void Main()
    {
        Console.Write("Please, enter a lenght for the first array: ");
        int firstArrayLenght = int.Parse(Console.ReadLine());
        char[] firstArray = FillArray(firstArrayLenght);
        
        Console.Write("Please, enter a lenght for the first array: ");
        int secondArrayLenght = int.Parse(Console.ReadLine());
        char[] secondArray = FillArray(secondArrayLenght);


        if (firstArrayLenght == secondArrayLenght)
        {
            Array.Sort(firstArray);
            Array.Sort(secondArray);

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
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

    private static char[] FillArray(int arrayLenght)
    {
        char[] array = new char[arrayLenght];
        for (int i = 0; i < arrayLenght; i++)
        {
            Console.Write("First array[{0}] = ", i);
            array[i] = char.Parse(Console.ReadLine());
        }

        return array;
    }
}

