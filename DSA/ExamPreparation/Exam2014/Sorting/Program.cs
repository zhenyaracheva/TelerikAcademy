namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();
            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();
            
            var k = int.Parse(Console.ReadLine());
            var perm = new Permutation(nums, 0);

            var res = GetMinPath(perm, k);
            Console.WriteLine(res);
        }

        private static int GetMinPath(Permutation perm, int k)
        {
            var queue = new Queue<Permutation>();
            var visited = new HashSet<int>();

            queue.Enqueue(perm);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (ChechIfSorted(current.Number))
                {
                    return current.Path;
                }

                for (int i = 0; i <= current.Number.Length - k; i++)
                {
                    var nextPerm = current.Number.Clone() as int[];
                    Array.Reverse(nextPerm, i, k);
                    var next = new Permutation(nextPerm, current.Path + 1);

                    if (!visited.Contains(next.GetHashCode()))
                    {
                        queue.Enqueue(next);
                        visited.Add(next.GetHashCode());
                    }
                }
            }

            return -1;
        }

        private static bool ChechIfSorted(int[] number)
        {
            for (int i = 1; i < number.Length; i++)
            {
                if (number[i - 1] > number[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Permutation
    {
        public Permutation(int[] perm, int path)
        {
            this.Number = perm;
            this.Path = path;
        }

        public int[] Number { get; set; }

        public int Path { get; set; }

        public override int GetHashCode()
        {
            var res = 0;

            for (int i = 0; i < this.Number.Length; i++)
            {
                res += this.Number[i];
                res *= 10;
            }

            return res / 10;
        }
    }
}
