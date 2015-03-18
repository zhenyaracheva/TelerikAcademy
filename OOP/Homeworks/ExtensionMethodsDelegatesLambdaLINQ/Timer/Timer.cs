// Problem 7. Timer

// Using delegates write a class Timer that can execute certain method at each t seconds.
namespace Timer
{
    using System;
    using System.Threading;

    public delegate void TimerRepeat(DateTime time);

    public class Timer
    {
        public static void Main()
        {
            Console.Write("Please, enter interval in seconds: ");
            int seconds = int.Parse(Console.ReadLine());
            Console.WriteLine(DateTime.Now);

            TimerRepeat temp = new TimerRepeat(PrintDateTime);
            {
                while (true)
                {
                    Thread.Sleep(seconds * 1000);
                    temp(DateTime.Now);
                }
            }
        }

        public static void PrintDateTime(DateTime date)
        {
            Console.WriteLine("{0}", DateTime.Now);
        }
    }
}
