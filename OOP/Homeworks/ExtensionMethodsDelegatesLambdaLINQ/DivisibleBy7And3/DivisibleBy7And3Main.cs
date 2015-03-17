// Problem 6. Divisible by 7 and 3
   
// Write a program that prints from given array of integers all numbers that are 
// divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
namespace DivisibleBy7And3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DivisibleBy7And3Main
    {
        public static void Main()
        {
            var numbers = new List<int>() { 5, 10, 441, 15, 48, 56, 1323, 3087, 7, 36, 54, 7, 81, 35, 6875, 4, 2, 1, 21 };
            Console.WriteLine("Test first method using extension methods and lambda expressions:");
            PrintNumbers(DivisibleBy3And7(numbers));
            Console.WriteLine("Test second method using linq:");
            PrintNumbers(DivisibleBy3And7Linq(numbers));
        }

        public static IEnumerable<int> DivisibleBy3And7(IEnumerable<int> numbers)
        {
            var divisible = numbers.Where(num => (num % 7 == 0 && num % 3 == 0))
                                   .OrderBy(num => num);

            return divisible.ToList();
        }

        public static IEnumerable<int> DivisibleBy3And7Linq(IEnumerable<int> numbers)
        {
            var divisible =
                from number in numbers
                where number % 7 == 0 && number % 3 == 0
                orderby number
                select number;

            return divisible.ToList();
        }

        public static void PrintNumbers(IEnumerable<int> numbers)
        {
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
