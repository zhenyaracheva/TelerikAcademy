//Problem 9. Print a Sequence

//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

using System;
using System.Text;

class Sequence
{
    static void Main()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 2; i < 12; i++)
        {

            if (i % 2 == 0)
            {
                result.AppendFormat("{0}, ", i);
            }
            else
            {
                result.AppendFormat("-{0}, ", i);
            }
        }

        result.Length -= 2;
        Console.WriteLine(result.ToString());
    }
}

