// Problem 7. Timer

// Using delegates write a class Timer that can execute certain method at each t seconds.
namespace Timer
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Timer
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            Console.Write("Please, enter interval in seconds: ");
            int seconds = int.Parse(Console.ReadLine());
            Console.WriteLine(DateTime.Now);

            Action<string> temp = Console.WriteLine;
            {
                while (true)
                {
                    Thread.Sleep(seconds * 1000);
                    temp(DateTime.Now.ToString());
                }
            }
        }
    }
}
