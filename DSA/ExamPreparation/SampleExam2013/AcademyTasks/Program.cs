namespace AcademyTasks
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();

            var variety = int.Parse(Console.ReadLine());

            var counter = 1;
            var min = numbers[0];
            var max = numbers[0];
            
            for (int i = 0; i < numbers.Length - 2; i += 2)
            {
                counter++;

                var currentMax = Math.Max(numbers[i + 1], numbers[i + 2]);
                var currentMin = Math.Min(numbers[i + 1], numbers[i + 2]);

                if (min > currentMin)
                {
                    min = currentMin;
                }

                if (currentMax > max)
                {
                    max = currentMax;
                }

                var currentVariaty = Math.Abs(min - max);

                if (currentVariaty >= variety)
                {
                    Console.WriteLine(counter);
                    return;
                }
            }
        }
    }
}
