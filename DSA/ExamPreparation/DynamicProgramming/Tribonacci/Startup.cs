namespace Tribonacci
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToList();
            var n = numbers[3];
            numbers.RemoveAt(numbers.Count() - 1);

            while (numbers.Count() != n)
            {
                var index = numbers.Count() - 1;
                var first = numbers[index - 2];
                var second = numbers[index - 1];
                var third = numbers[index];

                var next = first + second + third;
                numbers.Add(next);
            }

            Console.WriteLine(numbers.Last());
        }
    }
}
