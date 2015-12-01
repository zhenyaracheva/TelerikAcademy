namespace Workshop
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var answer = Palidromize(input);

            Console.WriteLine(answer);
        }

        private static string Palidromize(string input)
        {
            if (IsPalindrome(input))
            {
                return input;
            }


            for (int i = 0; i < input.Length; i++)
            {
                var firstChars = input.Substring(0, i).ToCharArray();
                Array.Reverse(firstChars);

                var candidate = input + string.Join("", firstChars);

                if (IsPalindrome(candidate))
                {
                    return candidate;
                }

            }

            return string.Empty;
        }

        private static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
