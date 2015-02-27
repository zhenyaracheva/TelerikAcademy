//Problem 2. Enter numbers

//Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
//If an invalid number or non-number text is entered, the method should throw an exception.
//Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class SolveEnterNumbers
{


    static void Main()
    {
        try
        {
            //Console.Write("Please, enter star index: ");
            //int starIndex = int.Parse(Console.ReadLine());
            //Console.Write("Please, enter end index: ");
            //int endIndex = int.Parse(Console.ReadLine());
            //Console.Write("Please, enter count: ");
            //int count = int.Parse(Console.ReadLine());
            //ReadNumbers(starIndex, endIndex, count);

            ReadNumbers(1, 100, 10);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception)
        {

            throw;
        }
    }

    static int ReadNumber(int start, int end)
    {
        Console.Write("Please, enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException();
        }

        return number;
    }

    private static void ReadNumbers(int start, int end, int count)
    {
        int[] arrayOfNumbers = new int[count];

        for (int i = 0; i < count; i++)
        {
            arrayOfNumbers[i] = ReadNumber(start, end);

            if (i >= 1)
            {
                if (arrayOfNumbers[i] < arrayOfNumbers[i - 1])
                {
                    throw new ArgumentException("Invaid number! Current number cannot be smaller than previous number!");
                }
            }
        }
    }
}
