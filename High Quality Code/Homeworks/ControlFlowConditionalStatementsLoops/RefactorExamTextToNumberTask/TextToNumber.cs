namespace RefactorExamTextToNumberTask
{
    using System;

    public class TextToNumber
    {
        public static void Main()
        {
            int module = int.Parse(Console.ReadLine());
            string text = Console.ReadLine().ToUpper();
            long result = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    result *= int.Parse(text[i].ToString());
                }
                else if (char.IsLetterOrDigit(text[i]))
                {
                    int characterNumber = (int)text[i] - 65;
                    result += characterNumber;
                }
                else if (text[i] == '@')
                {
                    Console.WriteLine(result);
                    break;
                }
                else
                {
                    result = result % module;
                }
            }
        }
    }
}
