namespace Guitar
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var songs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();

            var startValue = int.Parse(Console.ReadLine());
            var maxValue = int.Parse(Console.ReadLine());

            var currentResult = new bool[maxValue + 1];
            currentResult[startValue] = true;

            var final = new bool[maxValue + 1];

            for (int i = 0; i < songs.Length; i++)
            {
                for (int j = 0; j < final.Length; j++)
                {
                    if (currentResult[j])
                    {
                        if (j + songs[i] < final.Length)
                        {
                            final[j + songs[i]] = true;
                        }

                        if (j - songs[i] >= 0)
                        {
                            final[j - songs[i]] = true;
                        }
                    }
                }

                currentResult = final;
                final = new bool[maxValue + 1];
            }

            for (int i = currentResult.Length - 1; i >= 0; i--)
            {
                if (currentResult[i])
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}
