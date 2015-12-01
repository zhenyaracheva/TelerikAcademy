namespace Towns
{
    using System;

    public class Program
    {
        private static int maxPath = 0;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var towns = new int[n];

            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine().Split(' ');
                towns[i] = int.Parse(current[0]);
            }

            GetMaxSum(towns);
            Console.WriteLine(maxPath);
        }

        private static void GetMaxSum(int[] towns)
        {
            var leftRight = new int[towns.Length];
            var rightLeft = new int[towns.Length];
            leftRight[0] = 1;
            int maxLenght = 1;

            for (int i = 0; i < rightLeft.Length; i++)
            {
                rightLeft[i] = 1;
                leftRight[i] = 1;
            }

            for (var i = 1; i < towns.Length; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    if (towns[i] > towns[j] && leftRight[i] < leftRight[j] + 1)
                    {
                        leftRight[i] = leftRight[j] + 1;
                        if (maxLenght < leftRight[i])
                        {
                            maxLenght = leftRight[i];
                        }
                    }
                }
            }
            
            for (int i = towns.Length - 1; i >= 0; i--)
            {
                for (int j = towns.Length - 1; j > i; j--)
                {
                    if (towns[i] > towns[j] && rightLeft[i] < rightLeft[j] + 1)
                    {
                        rightLeft[i] = rightLeft[j] + 1;
                        if (maxLenght < rightLeft[i])
                        {
                            maxLenght = rightLeft[i];
                        }
                    }
                }
            }
            
            for (int i = 0; i < towns.Length; i++)
            {
                var currentPath = leftRight[i] + rightLeft[i] - 1;
                if (currentPath > maxPath)
                {
                    maxPath = currentPath;
                }
            }
        }
    }
}
