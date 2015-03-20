// Problem 20.* Infinite convergent series

// By using delegates develop an universal static method to calculate the sum of infinite convergent series with given 
// precision depending on a function of its term. By using proper functions for the term calculate with a 2-digit precision the 
// sum of the infinite series:

// 1 + 1/2 + 1/4 + 1/8 + 1/16 + …
// 1 + 1/2! + 1/3! + 1/4! + 1/5! + …
// 1 + 1/2 - 1/4 + 1/8 - 1/16 + …
namespace InfiniteConvergentSeries
{
    using System;

    public class InfiniteConvergentSeriesMain
    {
        public static void Main()
        {
            Func<long, double> getSum = GetSum;
            Func<long, double> getSumAndMinus = GetSumAndMinus;
            Func<long, double> getFactorial = SumFactorial;

            Console.Write("Please enter integer precision: ");
            long precision = CheckValidN();
            Console.WriteLine("1 + 1 / 2 + 1 / 4 + 1 / 8 + 1 / 16...");
            Console.WriteLine("Precision: {0}", precision);
            Console.WriteLine("Result: {0:F2}", getSum(precision));
            Console.WriteLine();
            Console.WriteLine("1 + 1 / 2! + 1 / 3! + 1 / 4! + 1 / 5!...");
            Console.WriteLine("Precision: {0}", precision);
            Console.WriteLine("Result: {0:F2}", getFactorial(precision));
            Console.WriteLine();
            Console.WriteLine("1 + 1 / 2 - 1 / 4 + 1 / 8 - 1 / 16...");
            Console.WriteLine("Precision: {0}", precision);
            Console.WriteLine("Result: {0:F2}", getSumAndMinus(precision));
        }

        private static long CheckValidN()
        {
            long precision = long.Parse(Console.ReadLine());

            while (precision < 0)
            {
                Console.Write("Invalid input! Precision cannot be smaller than 0! Try again: ");
                precision = long.Parse(Console.ReadLine());
            }

            return precision;
        }

        private static double GetSum(long n)
        {
            double sum = 0.0;
            for (long i = 1, j = 1; j <= n; j++, i *= 2)
            {
                sum += 1.0 / i;
            }

            return sum;
        }

        private static double SumFactorial(long n)
        {
            double sum = 0;

            for (long i = 1; i <= n; i++)
            {
                double factorial = 1;
                for (long j = 1; j <= i; j++)
                {
                    factorial *= j;
                }

                sum += 1.0 / factorial;
            }

            return sum;
        }

        private static double GetSumAndMinus(long n)
        {
            if (n == 0)
            {
                return 0.0;
            }

            double sum = 1.0;

            for (long i = 2, j = 2; j <= n; j++, i *= 2)
            {
                if (j % 2 == 0)
                {
                    sum += 1.0 / i;
                }
                else
                {
                    sum -= 1.0 / i;
                }
            }

            return sum;
        }

        public static void Output(double result)
        {
            Console.WriteLine(result);
        }
    }
}
