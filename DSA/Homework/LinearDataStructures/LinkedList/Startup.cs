namespace LinkedListStackQueue
{
    using System;
    using LinkedListStackQueue.LinkedLIstImplementation;

    public class Startup
    {
        public static void Main()
        {
           Console.WriteLine("Testtig Stack:");
           TestStack();
           Console.WriteLine();
           
           Console.WriteLine("Testtig Queue:");
           TestQueue();
           Console.WriteLine();
           
           Console.WriteLine("Testing LinkedList:");
            TestLinkedList();
        }

        private static void TestLinkedList()
        {
            var list = new LinkedList<int>();
            Console.WriteLine("Add First 5 elements:");
            for (int i = 1; i <= 5; i++)
            {
                list.AddFrist(i);
            }

            Console.WriteLine(list.ToString());

            Console.WriteLine("Add last 5 elements:");
            for (int i = 1; i <= 5; i++)
            {
                list.AddLast(i);
            }

            Console.WriteLine(list.ToString());

            Console.WriteLine("Remove 1:");
            list.Remove(1);
            Console.WriteLine(list.ToString());

            Console.WriteLine("Remove first element:");
            list.RemoveFirst();
            Console.WriteLine(list.ToString());

            Console.WriteLine("Remove last element:");
            list.RemoveLast();
            Console.WriteLine(list.ToString());
            Console.WriteLine("Remove last element:");
            list.RemoveLast();
            Console.WriteLine(list.ToString());

            Console.WriteLine("Contains 3: " + list.Contaians(3));
            Console.WriteLine("Contains 50: " + list.Contaians(50));
            Console.WriteLine("Elements count: " + list.Count);
            Console.WriteLine("First element: " + list.First);
            Console.WriteLine("Last element: " + list.Last);
            list.Clear();
            Console.WriteLine("Clear elements: " + list.ToString());
        }

        private static void TestStack()
        {
            var queue = new Stack<int>();
            Console.WriteLine("Adding 5 elements:");
            for (int i = 1; i <= 5; i++)
            {
                queue.Push(i);
            }

            Console.WriteLine(queue.ToString());

            Console.WriteLine("Delete 3 elements:");
            for (int i = 0; i < 3; i++)
            {
                queue.Pop();
            }

            Console.WriteLine(queue.ToString());

            Console.WriteLine("Last elemnt: " + queue.Peek());
            Console.WriteLine("Contains 5: " + queue.Contains(5));
            Console.WriteLine("Contains 7: " + queue.Contains(7));
            Console.WriteLine("Stack count: " + queue.Count);
            Console.WriteLine("Stack capacity:" + queue.Capacity);
            queue.Trim();
            Console.WriteLine("Stack capacity after trim: " + queue.Capacity);
            queue.Clear();
            Console.WriteLine("Stack elements after clear: " + queue.ToString());
        }

        private static void TestQueue()
        {
            var stack = new Queue<int>();
            Console.WriteLine("Adding 5 elements:");
            for (int i = 1; i <= 5; i++)
            {
                stack.Enqueue(i);
            }

            Console.WriteLine(stack.ToString());

            Console.WriteLine("Delete 3 elements:");
            for (int i = 0; i < 3; i++)
            {
                stack.Dequeue();
            }

            Console.WriteLine(stack.ToString());

            Console.WriteLine("First elemnt: " + stack.Peek());
            Console.WriteLine("Contains 2: " + stack.Contains(2));
            Console.WriteLine("Contains 7: " + stack.Contains(7));
            Console.WriteLine("Queue count: " + stack.Count);
            Console.WriteLine("Queue capacity:" + stack.Capacity);
            stack.Trim();
            Console.WriteLine("Queue capacity after trim: " + stack.Capacity);
            stack.Clear();
            Console.WriteLine("Queue elements after clear: " + stack.ToString());
        }
    }
}