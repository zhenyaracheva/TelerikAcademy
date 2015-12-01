namespace Frames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        private static SortedSet<string> result = new SortedSet<string>();


        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var frames = new string[n];

            for (int i = 0; i < n; i++)
            {
                frames[i] = Console.ReadLine();
            }

            Perm(frames, 0);

            var output = new StringBuilder();

            output.AppendLine(result.Count.ToString());

            foreach (var item in result)
            {
                output.AppendLine(item);
            }

            Console.WriteLine(output.ToString().Trim());
        }

        static void Perm(string[] arr, int k)
        {
            if (k >= arr.Length)
            {
                var test = new StringBuilder();
                for (int i = 0; i < arr.Length; i++)
                {
                    var num = arr[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    test.Append(string.Format("({0}, {1}) | ", num[0], num[1]));
                }

                test.Length -= 3;

                result.Add(test.ToString());
            }
            else
            {
                Perm(arr, k + 1);
                arr[k] = string.Join("", arr[k].Reverse());
                Perm(arr, k + 1);
                arr[k] = string.Join("", arr[k].Reverse());

                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);

                    Perm(arr, k + 1);
                    arr[k] = string.Join("", arr[k].Reverse());
                    Perm(arr, k + 1);
                    arr[k] = string.Join("", arr[k].Reverse());

                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }
        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
