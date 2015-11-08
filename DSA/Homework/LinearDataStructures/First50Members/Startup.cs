namespace First50Members
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private const int NumbersToPrint = 50;

        public static void Main()
        {
            Console.Write("Enter number: ");
            var number = int.Parse(Console.ReadLine());
            var result = GetFirst50Numbers(number);
            Console.WriteLine(string.Join(", ", result.Take(NumbersToPrint)));
        }

        private static IList<int> GetFirst50Numbers(int number)
        {
            var queue = new Queue<int>();
            queue.Enqueue(number);

            var result = new List<int>();
            result.Add(number);

            while (result.Count() < NumbersToPrint)
            {
                var current = queue.Dequeue();
                var currentPlusOne = current + 1;
                var currentMultiplyTwo = (current * 2) + 1;
                var currentPlusTwo = current + 2;

                queue.Enqueue(currentPlusOne);
                queue.Enqueue(currentMultiplyTwo);
                queue.Enqueue(currentPlusTwo);
                result.AddRange(new[] { currentPlusOne, currentMultiplyTwo, currentPlusTwo });
            }

            return result;
        }
    }
}
