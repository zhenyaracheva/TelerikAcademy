namespace SuperSum
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var k = int.Parse(numbers[0]);
            var n = int.Parse(numbers[1]);

            var memo = new int?[k + 1, n + 1];

            for (int i = 0; i <= k; i++)
            {
                memo[i, 0] = 0;
            }

            for (int i = 0; i <= n; i++)
            {
                memo[0, i] = i;
            }

            for (int row = 1; row <= k; row++)
            {
                for (int col = 1; col <= n; col++)
                {
                    memo[row, col] = memo[row - 1, col] + memo[row, col - 1];
                }
            }

            Console.WriteLine(memo[k, n]);
        }
    }
}