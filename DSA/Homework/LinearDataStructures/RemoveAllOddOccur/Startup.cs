namespace RemoveAllOddOccur
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var test = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var index = test.Count();

            for (int i = 0; i < index; i++)
            {
                var currentNumber = test[i];
                var count = test.Count(n => n == currentNumber);

                if (count % 2 == 1)
                {
                    test.RemoveAll(num => (num == currentNumber));
                    index -= count;
                }
            }

            Console.WriteLine(string.Join(", ", test));
        }
    }
}
