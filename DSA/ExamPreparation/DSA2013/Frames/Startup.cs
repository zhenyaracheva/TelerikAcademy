namespace Frames
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        private static List<string> comb = new List<string>();
        private static string[] numbers;
        private static int n;
        private static List<string> result = new List<string>();


        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            numbers = new string[n];

            for (int i = 0; i < n; i++)
            {
                var num = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                numbers[i] = "(" + string.Join(", ", num) + ")";
            }
            Array.Sort(numbers);
            CombReps(new string[n], 0, 0);
            
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < comb.Count; j++)
                {


                    if (!comb[j].Contains(numbers[i]))
                    {
                        var buider = new StringBuilder();
                        buider.Append(numbers[i]);
                        buider.Append(" | " + comb[j]);
                        result.Add(buider.ToString());
                    }


                }
            }

            Console.WriteLine(result.Count);
            Console.WriteLine(string.Join("\n", result));
        }


        static void CombReps(string[] arr, int index, int start)
        {
            if (index >= n - 1)
            {
                comb.Add(string.Join(" | ", arr));
            }
            else
                for (int i = 0; i < n; i++)
                {
                    arr[index] = numbers[i];
                    CombReps(arr, index + 1, i);
                }
        }

        private static void PermuteRep(string[] arr, int start, int n)
        {
            comb.Add(string.Join(" | ", arr));

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                    if (arr[left] != arr[right])
                    {
                        var oldValue = arr[left];
                        arr[left] = arr[right];
                        arr[right] = oldValue;
                        PermuteRep(arr, left + 1, n);
                    }
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                    arr[i] = arr[i + 1];
                arr[n - 1] = firstElement;
            }
        }
    }
}
