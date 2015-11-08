namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var test = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 7, 8, 9, 10 };
            var test2 = new List<int>() { 4, 7, 7, 7, 7, 3, 5, 4, 4, 4, 4, 4 };
            var res = GetMaxSunsequence(test2);

            Console.WriteLine(string.Join(" ", res));
        }

        private static IList<int> GetMaxSunsequence(List<int> list)
        {
            var counter = 1;
            var maxLenght = 0;
            var maxNumber = int.MinValue;

            for (int i = 0; i < list.Count; i++)
            {
                if (i + 1 < list.Count && list[i] == list[i + 1])
                {
                    counter++;
                }
                else
                {
                    if (maxLenght < counter)
                    {
                        maxLenght = counter;
                        maxNumber = list[i];
                    }

                    counter = 1;
                }
            }

            var result = new List<int>();
            for (int i = 0; i < maxLenght; i++)
            {
                result.Add(maxNumber);
            }

            return result;
        }
    }
}