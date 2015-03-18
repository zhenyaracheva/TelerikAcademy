namespace Events
{
    using System;

    public class EventMain
    {
        public static void Main()
        {
            Console.Write("Please, enter interval in seconds: ");
            int seconds = int.Parse(Console.ReadLine());
            Console.WriteLine(DateTime.Now);

            Timer timer = new Timer();
            Output output = new Output();
            output.Subscribe(timer);
            timer.Start(seconds);
        }
    }
}
