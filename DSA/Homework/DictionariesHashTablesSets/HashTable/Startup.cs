namespace HashTable
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var set = new HashedSet<int>();

            for (int i = 1; i <= 50; i++)
            {
                set.Add(i);
            }

            Console.WriteLine("Adding 50 elements: ");
            Console.WriteLine("Result: " + set.ToString());
            Console.WriteLine("-------------------------");

            for (int i = 25; i <= 50; i++)
            {
                set.Remove(i);
            }

            Console.WriteLine("Deleting last 25 elements: ");
            Console.WriteLine("Result: " + set.ToString());

            Console.WriteLine("-------------------------");
            Console.WriteLine("Set contains 15:" + set.Find(15));
            Console.WriteLine("Set contains 1005:" + set.Find(1005));

            var set2 = new HashedSet<int>();
            for (int i = 20; i <= 50; i++)
            {
                set2.Add(i);
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Union with set with elements 20...50");
            Console.WriteLine("Result: " + set.Union(set2).ToString());

            Console.WriteLine("-------------------------");
            Console.WriteLine("Intersect with set with elements 20...50");
            Console.WriteLine("Result: " + set.Intersect(set2).ToString());

            set.Clear();
            Console.WriteLine("Clear set:");
            Console.WriteLine("Result:" + set.ToString());
        }
    }
}
