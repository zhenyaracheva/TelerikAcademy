//Problem 8. Prime Number Check

//Write an expression that checks if given positive integer number n (n = 100) is prime (i.e. it is divisible without remainder only
//to itself and 1).
//Examples:

// n	    Prime?
// 1	    false
// 2	    true
// 3	    true
// 4	    false
// 9	    false
// 97	    true
// 51	    false
// -3	    false
// 0	    false

using System;

class PrimeNumbers
{
    static void Main()
    {
        Console.WriteLine("Check if given positive integer number n (n = 100) is prime");
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        int number = Math.Abs(n);

        bool isPrime = false;
        int counter = 0;
        int checkTo = (int)Math.Sqrt(number);

        if (number != 0 && number != 1)
        {
            for (int i = 1; i <= checkTo; i++)
            {
                if (number % i == 0)
                {
                    counter++;
                }
            }
        }

        if (counter == 1)
        {
            isPrime = true;
        }


        Console.WriteLine(isPrime);
    }
}

