namespace MessagesInABottle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        private static int count = 0;
        private static string message;
        private static Dictionary<string, char> letters;
        private static SortedSet<string> results = new SortedSet<string>();

        public static void Main()
        {
            message = Console.ReadLine();
            var code = Console.ReadLine();

            var number = new StringBuilder();
             letters = new Dictionary<string, char>();

            var lastLetter = code[0];

            for (int i = 1; i < code.Length; i++)
            {
                if (char.IsLetter(code[i]))
                {
                    var currentLetter = code[i];

                    letters.Add(number.ToString(), lastLetter);
                    number.Clear();

                    lastLetter = currentLetter;
                }
                else
                {
                    number.Append(code[i]);
                }
            }

            if (number.Length > 0)
            {
                letters.Add(number.ToString(), lastLetter);
            }

            GetMessage();
            Console.WriteLine(results.Count);
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }



        private static void GetMessage()
        {

            var queue = new Queue<KeyValuePair<StringBuilder, StringBuilder>>();
            queue.Enqueue(new KeyValuePair<StringBuilder, StringBuilder>(new StringBuilder(), new StringBuilder()));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Key.ToString() == message)
                {
                    results.Add(current.Value.ToString());
                }
                else
                {

                    foreach (var item in letters)
                    {
                        var currentNumbers = new StringBuilder(current.Key.ToString());
                        var currentLetters = new StringBuilder(current.Value.ToString());

                        currentNumbers.Append(item.Key);
                        currentLetters.Append(item.Value);

                        if (message.StartsWith(currentNumbers.ToString()))
                        {
                            queue.Enqueue(new KeyValuePair<StringBuilder, StringBuilder>(currentNumbers, currentLetters));
                        }
                    }
                }
            }
        }
    }
}
