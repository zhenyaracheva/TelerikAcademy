namespace Exam.SumOfDifferences
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class SolveSumOfDifferences
    {
        public static void Main()
        {
            long[] input = Console.ReadLine()
                                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(long.Parse)
                                  .ToArray();

            int index = 1;
            BigInteger allDifferences = 0;

            while (index < input.Length)
            {
                long difference = AbsoluteDifference(input[index], input[index - 1]);

                if (difference % 2 == 0)
                {
                    index += 2;
                }
                else
                {
                    allDifferences += difference;
                    index++;
                }
            }

            Console.WriteLine(allDifferences);
        }

        private static long AbsoluteDifference(long first, long second)
        {
            if (first == second)
            {
                return 0;
            }
            else if (first > second)
            {
                return first - second;
            }
            else
            {
                return second - first;
            }
        }
    }
}
