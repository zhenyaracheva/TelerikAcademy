//Problem 8. Number as array

//Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Linq;
using System.Text;

class AddNumberAsArray
{
    static void Main()
    {
        Console.WriteLine("Please, enter 2 positive integers:");
        Console.Write("First integer: ");
        uint firstNumber = uint.Parse(Console.ReadLine());
        int[] firstArray = ConvertToIntArray(firstNumber);


        Console.Write("Second integer: ");
        uint secondNumber = uint.Parse(Console.ReadLine());
        int[] secondArray = ConvertToIntArray(secondNumber);
        int[] result = AddArrays(firstArray, secondArray);

        Print(result);
    }

    private static void Print(int[] array)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write("{0}", array[i]);
        }

        Console.WriteLine();
    }

    private static int[] AddArrays(int[] firstArray, int[] secondArray)
    {
        if (firstArray.Length < secondArray.Length)
        {
            return AddArrays(secondArray, firstArray);
        }

        int remainder = 0;
        StringBuilder result = new StringBuilder();
        int add;

        for (int i = 0; i < firstArray.Length; i++)
        {
            if (i < secondArray.Length)
            {
                add = firstArray[i] + secondArray[i];
            }
            else
            {
                add = firstArray[i];
            }


            if (add > 9 && (i + 1) < firstArray.Length)
            {
                result.Insert(0, add % 10);
                remainder = add / 10;
                firstArray[i + 1] += remainder;
            }
            else
            {
                result.Insert(0, add);
            }
        }

        return ConvertToIntArray(uint.Parse(result.ToString()));
    }

    private static int[] ConvertToIntArray(uint firstNumber)
    {
        char[] temp = firstNumber.ToString().ToCharArray().Reverse().ToArray();
        int[] intArray = new int[temp.Length];

        for (int i = 0; i < temp.Length; i++)
        {
            intArray[i] = temp[i] - '0';
        }

        return intArray;
    }
}

