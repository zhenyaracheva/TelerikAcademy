namespace RefactorLoop
{
    using System;

    public class RefactorLoop
    {
        public static void Main(string[] args)
        {
            var array = new int[100];
            var expectedValue = 15;

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}
