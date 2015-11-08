namespace OperationsTask
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            Console.Write("Enter N: ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("Enter M: ");
            var m = int.Parse(Console.ReadLine());

            var res = ShortestSequenceOfOperations(n, m);
            Console.WriteLine(string.Join(" -> ", res));
        }

        private static Stack<int> ShortestSequenceOfOperations(int start, int end)
        {
            var result = new Stack<int>();

            while (start <= end)
            {
                result.Push(end);

                if (end / 2 >= start)
                {
                    if (end % 2 == 0)
                    {
                        end /= 2;
                    }
                    else
                    {
                        end--;
                    }

                }
                else
                {
                    if (end - 2 >= start)
                    {
                        end -= 2;
                    }
                    else
                    {
                        end--;
                    }

                }
            }

            return result;
        }
    }
}