namespace SumAndAverageOfTheElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = GetListOfNubersFromUser();
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Average: " + numbers.Average());
        }

        private static List<int> GetListOfNubersFromUser()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(num => int.Parse(num)).ToList();
            return numbers;
        }
    }
}
