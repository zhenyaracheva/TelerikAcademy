//Problem 10. Fibonacci Numbers

//Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence 
//(at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

using System;

class Fibonacci
{
    static void Main()
    {
        Console.Write("Enter positive number: ");
        int n = int.Parse(Console.ReadLine());

        int firstNumber = 0;
        int secondNumber = 1;
       
        while (n != 0)
        {
            Console.Write("{0} ", firstNumber);
            secondNumber = firstNumber + secondNumber;
            firstNumber = secondNumber - firstNumber;
            n--;
        }

        Console.WriteLine();
       
    }
}

