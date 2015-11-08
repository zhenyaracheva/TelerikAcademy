namespace TreeTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var n = 7; // int.Parse(Console.ReadLine());
            var relations = new string[] { "2 4", "3 2", "5 0", "3 5", "5 6", "5 1" };

            var nodes = GetNodes(relations, n); //new Node<int>[N];
            // 01. Print root
            var root = FindRood(nodes);
            Console.WriteLine("Root is: " + root.Value);

            // 02. Print all leaf nodes
            var leafs = GetAllLeafs(nodes);
            Console.WriteLine("Leafs are: " + string.Join(", ", leafs));

            // 03. Print all middle nodes
            var middleNodes = GetAllMiddleNodes(nodes);
            Console.WriteLine("Middle nodes are: " + string.Join(", ", middleNodes));

            // 04. Longest path in tree
            var longestPath = FindLongestPath(root);
            Console.WriteLine("Longest path is: " + longestPath);

            // 05. All paths in the tree with given sum `S` of their nodes from the root
            Console.WriteLine("Paths with sum 9:");
            AllPathsWithGivenSum(root, 0, 9, new List<Node<int>>());

            // 06. All subtrees with given sum `S` of their nodes
            Console.WriteLine("Subtrees with sum 6:");
            SubtreesBySum(root, 6);
        }

        private static void SubtreesBySum(Node<int> root, int maxSum)
        {
            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                var currentSum = node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                    currentSum += child.Value;
                }

                if (currentSum == maxSum)
                {
                    var childrenAsString = node.Children.Count == 0 ? "No Children" : string.Join(", ", node.Children);
                    Console.WriteLine("{0} -> {1}", node.Value, childrenAsString);
                }
            }
        }

        private static Node<int>[] GetNodes(string[] relations, int n)
        {
            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < relations.Length; i++)
            {
                var nodeRelation = relations[i].Split(' ');
                var parent = int.Parse(nodeRelation[0]);
                var child = int.Parse(nodeRelation[1]);

                nodes[parent].AddChild(nodes[child]);
            }

            return nodes;
        }

        private static void AllPathsWithGivenSum(Node<int> root, int currentSum, int maxSum, List<Node<int>> nodes)
        {
            currentSum += root.Value;
            nodes.Add(root);

            if (currentSum == maxSum)
            {
                Console.WriteLine(string.Join(", ", nodes));
            }

            foreach (var node in root.Children)
            {
                AllPathsWithGivenSum(node, currentSum, maxSum, nodes);
            }

            nodes.Remove(root);
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        private static IList<Node<int>> GetAllMiddleNodes(Node<int>[] nodes)
        {
            var middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (!node.IsLeaf && node.HasParent)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static IList<Node<int>> GetAllLeafs(Node<int>[] nodes)
        {
            var leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.IsLeaf)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static Node<int> FindRood(Node<int>[] nodes)
        {
            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("Tree doesn't have a root!");
        }

        private static void PrintNodes(Node<int>[] nodes)
        {
            foreach (var node in nodes)
            {
                var childrenAsString = node.Children.Count > 0 ? string.Join(", ", node.Children) : "No Children";
                Console.WriteLine(node.Value + "->" + childrenAsString);
            }
        }
    }
}
