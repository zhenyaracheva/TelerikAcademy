//Problem 5. Larger than neighbours

//Write a method that checks if the element at given position in given array of integers is larger than 
//its two neighbours (when such exist).

using System;

class CheckLargerThanNeighbours
{
    static void Main()
    {
        Console.WriteLine("Please, enter an array of integers (separate by space):");
        string[] arrayOfStrings = CheckArray();
        int[] arrayOfNumbers = ConvertArrayToInt(arrayOfStrings);

        Console.Write("Please, enter position: ");
        int position = int.Parse(Console.ReadLine());

        if (CheckValidPosition(arrayOfNumbers.Length, position))
        {
            if (LargerThanNeighbours(arrayOfNumbers, position))
            {
                Console.WriteLine("Number on position {0} is bigger than its neighbours!", position);
            }
            else
            {
                Console.WriteLine("Number on position {0} is NOT bigger than its neighbours!", position);
            }
        }
        else
        {
            Console.WriteLine("Position is outside the array!");
        }
    }

    private static bool LargerThanNeighbours(int[] arrayOfNumbers, int position)
    {
        if (position == 0)
        {
            return arrayOfNumbers[position] > arrayOfNumbers[position + 1] ? true : false;
        }
        else if (position == arrayOfNumbers.Length - 1)
        {
            return arrayOfNumbers[position] > arrayOfNumbers[position - 1] ? true : false;
        }
        else
        {
            if (arrayOfNumbers[position] > arrayOfNumbers[position - 1] && arrayOfNumbers[position] > arrayOfNumbers[position + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private static bool CheckValidPosition(int arratLenght, int position)
    {
        if (position < 0 || position > arratLenght - 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }



    private static int[] ConvertArrayToInt(string[] arrayOfStrings)
    {
        int[] arrayOfNumbers = new int[arrayOfStrings.Length];

        for (int i = 0; i < arrayOfStrings.Length; i++)
        {
            arrayOfNumbers[i] = int.Parse(arrayOfStrings[i]);
        }

        return arrayOfNumbers;
    }

    private static string[] CheckArray()
    {
        string[] arrayOfStrings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (arrayOfStrings.Length <= 0)
        {
            Console.WriteLine("Empty array! Try again:");
            arrayOfStrings = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return arrayOfStrings;
    }
}

