//Problem 5. Maximal increasing sequence

//Write a program that finds the maximal increasing sequence in an array.
//Example:

//      input	                result
//3, 2, 3, 4, 2, 2, 4	        2, 3, 4

using System;
using System.Text;

class FindMaximalIncreasingSequence
{
    static void Main()
    {
        Console.WriteLine("Please, enter an array of integers(separate integers with \", \" or only space): ");
        string[] array = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (array.Length < 1)
        {
            Console.WriteLine("Empty array!");
        }
        else if (array.Length == 1)
        {
            Console.WriteLine(array[0]);
        }
        else
        {
            StringBuilder max = new StringBuilder();
            StringBuilder current = new StringBuilder();
            current.AppendFormat("{0}, ", array[0]);

            int lastNumber = int.Parse(array[0]);
            int maxNumber = lastNumber;

            for (int i = 1; i < array.Length; i++)
            {
                int currentNumber = int.Parse(array[i]);

                if (lastNumber + 1 == currentNumber)
                {
                    current.AppendFormat("{0}, ", currentNumber);
                }
                else
                {
                    if (max.Length < current.Length)
                    {
                        max.Clear();
                        max.Append(current);
                    }

                    current.Clear();
                    current.AppendFormat("{0}, ", currentNumber);
                }

                lastNumber = currentNumber;
            }

            max.Length -= 2;
            Console.WriteLine(max);
        }

    }
}

