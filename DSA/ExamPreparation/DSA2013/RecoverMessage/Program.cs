namespace RecoverMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static SortedDictionary<char, Node> graph = new SortedDictionary<char, Node>();


        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var words = new string[n];

            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                words[i] = word;

                if (word.Length == 1)
                {
                    var currentNode = GetNode(word[0]);
                }
                else
                {
                    for (int j = 1; j < word.Length; j++)
                    {
                        var prevNode = GetNode(word[j - 1]);
                        var currentNode = GetNode(word[j]);

                        currentNode.Parents.Add(prevNode);
                        prevNode.Children.Add(currentNode);
                    }
                }
            }

            var message = GetMessage();
            Console.WriteLine(message);

        }

        private static string GetMessage()
        {
            var result = new List<char>();
            var noParents = new List<char>();

            foreach (var item in graph)
            {
                if (item.Value.Parents.Count == 0)
                {
                    noParents.Add(item.Value.Letter);
                }
            }

            while (noParents.Count > 0)
            {
                var current = noParents.Min();
                noParents.Remove(current);
                result.Add(current);

                var node = GetNode(current);
                var children = node.Children;

                foreach (var child in children)
                {
                    child.Parents.Remove(node);
                    if (child.Parents.Count == 0)
                    {
                        noParents.Add(child.Letter);
                    }
                }
            }

            return string.Join("", result);
        }

        private static Node GetNode(char symbol)
        {
            if (graph.ContainsKey(symbol))
            {
                return graph[symbol];
            }
            else
            {
                var node = new Node(symbol);
                graph.Add(symbol, node);
                return node;
            }
        }
    }

    public class Node
    {
        public Node(char letter)
        {
            this.Letter = letter;
            this.Children = new List<Node>();
            this.Parents = new List<Node>();
        }

        public char Letter { get; set; }

        public ICollection<Node> Children { get; set; }

        public ICollection<Node> Parents { get; set; }
    }
}
