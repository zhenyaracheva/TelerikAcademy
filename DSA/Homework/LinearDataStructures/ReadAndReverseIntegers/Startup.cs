namespace ReadAndReverseIntegers
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var numberOfIntegers = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < numberOfIntegers; i++)
            {
                var number = int.Parse(Console.ReadLine());
                stack.Push(number);
            }

            ReverseStack(stack);
            Console.WriteLine(string.Join(", ", stack));
        }

        private static void ReverseStack(Stack<int> stack)
        {
            int temp;
            if (stack.Count > 0)
            {
                temp = stack.Pop();
                ReverseStack(stack);
                stack.Push(temp);
            }
        }
    }
}
