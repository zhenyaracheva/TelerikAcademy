namespace PriorityQueueTask
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var test = new PriorityQueue<int>();

            test.Add(50);
            test.Add(2);
            test.Add(5);
            test.Add(1);
            test.Add(17);
            test.Add(80);
            test.Add(569);

            Console.WriteLine(test.Count);
            Console.WriteLine(test.ToString());
            Console.WriteLine(test.Remove());
            Console.WriteLine(test.Remove());
            Console.WriteLine(test.Remove());
            Console.WriteLine(test.Remove());
            Console.WriteLine(test.Remove());
            Console.WriteLine(test.ToString());
            Console.WriteLine(test.Count);
        }
    }
}
