namespace RiskWinsRiskLoses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        private static HashSet<string> forbidenNumbers = new HashSet<string>();
        private const int Wheels = 5;

        public static void Main()
        {
            var startNumber = Console.ReadLine();
            var target = Console.ReadLine();

            var forbiddenNumbersCount = int.Parse(Console.ReadLine());
            forbidenNumbers.Add(startNumber);

            for (int i = 0; i < forbiddenNumbersCount; i++)
            {
                forbidenNumbers.Add(Console.ReadLine());
            }

            GetPath(startNumber, target);
        }

        private static void GetPath(string startNumber, string target)
        {
            var startNode = new Node(startNumber, 0);

            var queue = new Queue<Node>();
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Number == target)
                {
                    Console.WriteLine(currentNode.Path);
                    return;
                }



                for (int i = 0; i < Wheels; i++)
                {
                    if (currentNode.Number[i] != target[i])
                    {
                        var currentNumber = new StringBuilder(currentNode.Number);
                        var ch = currentNumber[i];
                        var upNumber = GetNextUp(currentNumber, ch, i);

                        if (!forbidenNumbers.Contains(upNumber))
                        {
                            var up = new Node(upNumber, currentNode.Path + 1);
                            queue.Enqueue(up);
                            forbidenNumbers.Add(upNumber);
                        }

                        var downNumber = GetNextDown(currentNumber, ch, i);

                        if (!forbidenNumbers.Contains(downNumber))
                        {
                            var down = new Node(downNumber, currentNode.Path + 1);
                            queue.Enqueue(down);
                            forbidenNumbers.Add(downNumber);
                        }
                    }
                }
            }

            Console.WriteLine("-1");
        }

        private static string GetNextUp(StringBuilder currentNumber, char ch, int i)
        {
            if (ch == '9')
            {
                ch = '0';
            }
            else
            {
                ch++;
            }
            currentNumber[i] = ch;
            return currentNumber.ToString();
        }

        private static string GetNextDown(StringBuilder currentNumber, char ch, int i)
        {
            if (ch == '0')
            {
                ch = '9';
            }
            else
            {
                ch--;
            }
            currentNumber[i] = ch;
            return currentNumber.ToString();
        }
    }

    public class Node
    {
        public Node(string number, int path)
        {
            this.Number = number;
            this.Path = path;
        }

        public string Number { get; set; }

        public int Path { get; set; }
    }
}
