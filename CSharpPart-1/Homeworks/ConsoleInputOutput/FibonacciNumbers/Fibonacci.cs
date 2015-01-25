//Problem 10. Fibonacci Numbers

//Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence 
//(at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

using System;
using System.Text;

class Fibonacci
{
    static void Main()
    {
        Console.Write("Enter positive number: ");
        int n = int.Parse(Console.ReadLine());

        if (n > 0)
        {
            int firstNumber = 0;
            int secondNumber = 1;
            StringBuilder result = new StringBuilder();

            while (n != 0)
            {
                result.AppendFormat("{0}, ", firstNumber);
                secondNumber = firstNumber + secondNumber;
                firstNumber = secondNumber - firstNumber;
                n--;
            }

            result.Length -= 2;
            Console.WriteLine(result.ToString());
        }
        else
        {
            Console.WriteLine("No numbers!");
        }


    }
}

