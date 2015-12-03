namespace MessageInABottle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Message
    {
        static string message;
        static string chipher;
        static List<KeyValuePair<char, string>> chiphers = new List<KeyValuePair<char, string>>();
        static List<string> solutions = new List<string>();

        static void Main(string[] args)
        {
            message = Console.ReadLine();
            chipher = Console.ReadLine();
            ReadInput();
            Solver(0, new StringBuilder());
            Print();

        }

        private static void Print()
        {
            solutions.Sort();
            Console.WriteLine(solutions.Count);

            foreach (var solution in solutions)
            {
                Console.WriteLine(solution);
            }
        }

        private static void Solver(int currentIndex, StringBuilder sb)
        {
            if (currentIndex == message.Length)
            {
                solutions.Add(sb.ToString());
                return;
            }

            foreach (var currentChipher in chiphers)
            {
                if (message.Substring(currentIndex).StartsWith(currentChipher.Value))
                {
                    sb.Append(currentChipher.Key);
                    Solver(currentIndex + currentChipher.Value.Length, sb);
                    sb.Length--;
                }
            }
        }

        private static void ReadInput()
        {
            char key = char.MinValue;
            StringBuilder value = new StringBuilder();

            for (int i = 0; i < chipher.Length; i++)
            {
                if (chipher[i] >= 'A' && chipher[i] <= 'Z')
                {
                    if (key != char.MinValue)
                    {
                        chiphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                        value.Clear();
                    }

                    key = chipher[i];
                }
                else
                {
                    value.Append(chipher[i]);
                }
            }

            if (key != char.MinValue)
            {
                chiphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }
        }
    }
}
