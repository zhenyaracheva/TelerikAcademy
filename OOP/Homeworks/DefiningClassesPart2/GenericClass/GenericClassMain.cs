namespace GenericClass
{
    using System;

    public class GenericClassMain
    {
        public static void Main()
        {
            GenericList<int> list = new GenericList<int>();

            for (int i = 1; i <= 20; i++)
            {
                list.Add(i);
            }

            Console.WriteLine("First list:");
            Console.WriteLine(list.ToString());

            list.Insert(10, 150);
            list.Insert(3, -50);
            Console.WriteLine("Insert some elements:");
            Console.WriteLine(list.ToString());

            Console.Write("Print min element: ");
            Console.WriteLine(list.Min());
            Console.Write("Print max element: ");
            Console.WriteLine(list.Max());

            list.RemoveElement(3);
            list.RemoveElement(10);
            Console.WriteLine("After removed elements:");
            Console.WriteLine(list.ToString());
        }
    }
}
