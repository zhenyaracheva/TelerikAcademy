//Problem 15. Prime numbers

//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.

using System;

class FindPrimeNumbers
{
    static void Main()
    {
        Console.Write("Please, enter number n [1...10 000 00]: ");
        int n = FindValidNumber();

        bool[] arrayPrimes = CreateTrueArray(n);

        int lengthPrimes = (int)Math.Sqrt((double)arrayPrimes.Length);

        for (int i = 0; i <= lengthPrimes; i++)
        {
            if (arrayPrimes[i])
            {

                for (int j = 2; (j * i) < arrayPrimes.Length; j++)
                {
                    arrayPrimes[j * i] = false;
                }
            }
        }

        int primesCount = 0;

        for (int i = 0; i < arrayPrimes.Length; i++)
        {
            if (arrayPrimes[i])
            {
                Console.Write("{0} ", i);
                primesCount++;
            }

        }

        if(primesCount==0)
        {
            Console.WriteLine("No primes numbers!");
        }
        else
        {
            Console.WriteLine();
        }
    }

    private static bool[] CreateTrueArray(int n)
    {
        bool[] boolArray = new bool[n + 1];

        for (int i = 2; i < boolArray.Length; i++)
        {
            boolArray[i] = true;
        }

        return boolArray;
    }

    private static int FindValidNumber()
    {
        int number = int.Parse(Console.ReadLine());

        while (number <= 0 || number > 10000000)
        {
            Console.Write("Invalid number! Try again: ");
            number = int.Parse(Console.ReadLine());
        }

        return number;
    }
}

