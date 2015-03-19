// Problem 17. Longest string

// Write a program to return the string with maximum length from an array of strings.
// Use LINQ.
namespace LongestString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindLongestString
    {
        public static void Main()
        {
            var listOfStrings = new List<string>() { "someString", "short", "min", "maxLenghtString", "anotherString", "justString" };
            var maxLenghtString = from strings in listOfStrings
                                  orderby strings.Length descending
                                  select strings;

            int maxLenght = maxLenghtString.First().Length;
            var result = from strings in maxLenghtString
                         where strings.Length == maxLenght
                         select strings;

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
