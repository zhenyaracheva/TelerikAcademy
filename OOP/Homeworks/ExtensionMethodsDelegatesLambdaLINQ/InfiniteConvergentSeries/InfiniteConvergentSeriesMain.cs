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
        public delegate double InfiniteSeries(int precision);
        public delegate void InfiniteSeriesPrint(int precision);

        public static void Main()
        {
            var dlgSum = new InfiniteSeries(GetSum);
            var dlgFactorial = new InfiniteSeries(SumFactorial);
            var dlgSumAndMinus = new InfiniteSeries(GetSumAndMinus);

            Console.Write("Please enter integer precision: ");
            int precision = CheckValidN();
            Console.WriteLine("1 + 1 / 2 + 1 / 4 + 1 / 8 + 1 / 16...");
            Console.WriteLine("{0} -> {1:F2}", precision, dlgSum(precision));
            Console.WriteLine();
            Console.WriteLine("1 + 1 / 2! + 1 / 3! + 1 / 4! + 1 / 5!...");
            Console.WriteLine("{0} -> {1:F2}", precision, dlgFactorial(precision));
            Console.WriteLine();
            Console.WriteLine("1 + 1 / 2 - 1 / 4 + 1 / 8 - 1 / 16...");
            Console.WriteLine("{0} -> {1:F2}", precision, dlgSumAndMinus(precision));
        }

        private static int CheckValidN()
        {
            int precision = int.Parse(Console.ReadLine());

            while (precision < 0)
            {
                Console.Write("Invalid input! Precision cannot be smaller than 0! Try again: ");
                precision = int.Parse(Console.ReadLine());
            }

            return precision;
        }

        private static double GetSum(int n)
        {
            double sum = 0.0;
            for (int i = 1, j = 1; j <= n; j++, i *= 2)
            {
                sum += 1.0 / i;
            }

            return sum;
        }

        private static double SumFactorial(int n)
        {
            double sum = 0;

            for (int i = 1; i <= n; i++)
            {
                double factorial = 1;
                for (int j = 1; j <= i; j++)
                {
                    factorial *= j;
                }

                sum += 1.0 / factorial;
            }

            return sum;
        }

        private static double GetSumAndMinus(int n)
        {
            if (n == 0)
            {
                return 0.0;
            }

            double sum = 1.0;

            for (int i = 2, j = 2; j <= n; j++, i *= 2)
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
