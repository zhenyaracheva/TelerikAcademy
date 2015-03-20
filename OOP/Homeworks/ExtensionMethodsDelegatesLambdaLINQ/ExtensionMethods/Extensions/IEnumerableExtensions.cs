/// Problem 1. StringBuilder.Substring
/// Implement an extension method Substring(int index, int length) for the class StringBuilder that returns 
/// new StringBuilder and has the same functionality as Substring in the class String.
/// Problem 2. IEnumerable extensions
/// Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
namespace ExtensionMethods.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> currentCollection)
            where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>, IFormattable
        {
            if (currentCollection.Count() == 0)
            {
                throw new ArgumentException("Collection is empty.");
            }

            dynamic sum = 0;

            foreach (var element in currentCollection)
            {
                sum += element;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> currentCollection)
            where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>, IFormattable
        {
            if (currentCollection.Count() == 0)
            {
                throw new ArgumentException("Collection is empty.");
            }

            dynamic result = 1;

            foreach (var element in currentCollection)
            {
                result *= element;
            }

            return result;
        }

        public static T Min<T>(this IEnumerable<T> currentCollection)
            where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>, IFormattable
        {
            if (currentCollection.Count() == 0)
            {
                throw new ArgumentException("Collection is empty.");
            }

            dynamic min = currentCollection.First();

            foreach (var element in currentCollection)
            {
                if (min > element)
                {
                    min = element;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> currentCollection)
            where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>, IFormattable
        {
            if (currentCollection.Count() == 0)
            {
                throw new ArgumentException("Collection is empty.");
            }

            dynamic max = currentCollection.First();

            foreach (var element in currentCollection)
            {
                if (max < element)
                {
                    max = element;
                }
            }

            return max;
        }

        public static double Average<T>(this IEnumerable<T> currentCollection)
            where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>, IFormattable
        {
            if (currentCollection.Count() == 0)
            {
                throw new ArgumentException("Collection is empty.");
            }

            double average = (dynamic)currentCollection.Sum() / (double)currentCollection.Count();

            return average;
        }
    }
}
