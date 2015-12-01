namespace ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        private static SortedSet<string> results = new SortedSet<string>();


        public static void Main()
        {
            var input = Console.ReadLine();
            var builder = new StringBuilder(input);
            var index = input.IndexOf("*");
            var stars = new Queue<StringBuilder>();

            if (index != -1)
            {
                stars.Enqueue(builder);
            }
            else
            {
                results.Add(input);
            }

            while (stars.Count != 0)
            {
                var current = stars.Dequeue();
                var currentIndex = current.ToString().IndexOf("*");

                var leftDirection = new StringBuilder(current.ToString());
                leftDirection[currentIndex] = 'L';

                var rightDirection = new StringBuilder(current.ToString());
                rightDirection[currentIndex] = 'R';

                var straightDirection = new StringBuilder(current.ToString());
                straightDirection[currentIndex] = 'S';

                if (leftDirection.ToString().IndexOf("*") == -1)
                {
                    results.Add(leftDirection.ToString());
                    results.Add(rightDirection.ToString());
                    results.Add(straightDirection.ToString());
                }
                else
                {
                    stars.Enqueue(leftDirection);
                    stars.Enqueue(rightDirection);
                    stars.Enqueue(straightDirection);
                }
            }

            Console.WriteLine(results.Count);

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
