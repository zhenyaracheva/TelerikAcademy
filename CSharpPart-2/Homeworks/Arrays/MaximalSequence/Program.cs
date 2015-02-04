//Problem 4. Maximal sequence

//Write a program that finds the maximal sequence of equal elements in an array.
//Example:

//          input	                    result
//2, 1, 1, 2, 3, 3, 2, 2, 2, 1	        2, 2, 2

using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Please, enter your array (separate elements with space): ");
        string[] array = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        if (array.Length>0)
        {
            int maxCount = 0;
            int currerntCount = 1;
            string maxSymbol = array[0];
            string lastSymbol = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (lastSymbol == array[i])
                {
                    currerntCount++;
                }
                else
                {
                    if (maxCount < currerntCount)
                    {
                        maxCount = currerntCount;
                        maxSymbol = lastSymbol;
                    }
                    currerntCount = 1;
                    lastSymbol = array[i];
                }
            }

            if (maxCount < currerntCount)
            {
                maxCount = currerntCount;
                maxSymbol = lastSymbol;
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < maxCount; i++)
            {
                result.AppendFormat("{0}, ", maxSymbol);
            }

            result.Length -= 2;
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Empty array!");
        }
       
    }
}
