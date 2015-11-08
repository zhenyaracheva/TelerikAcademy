namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using FindsSetOfWords;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Counting words...");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            TrieNode root = new TrieNode(null, '?');
            Dictionary<DataReader, Thread> readers = new Dictionary<DataReader, Thread>();

            args = new string[] { "../../text.txt" };

            var path = args[0];
            var reader = new DataReader(path, ref root);
            var thread = new Thread(reader.ThreadRun);
            readers.Add(reader, thread);
            thread.Start();

            foreach (Thread t in readers.Values)
            {
                t.Join();
            }

            sw.Stop();
            Console.WriteLine("Input data processed in {0} secs", sw.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Most commonly found words:");

            List<TrieNode> top10Nodes = new List<TrieNode> { root, root, root, root, root, root, root, root, root, root };
            int distinctWordCount = 0;
            int totalWordCount = 0;
            root.GetTopCounts(ref top10Nodes, ref distinctWordCount, ref totalWordCount);
            top10Nodes.Reverse();

            foreach (TrieNode node in top10Nodes)
            {
                if (node.WordCount > 0)
                {
                    Console.WriteLine("{0} - {1} times", node.ToString(), node.WordCount);
                }
            }

            Console.WriteLine();
            Console.WriteLine("{0} words counted", totalWordCount);
            Console.WriteLine("{0} distinct words found", distinctWordCount);
        }
    }
}