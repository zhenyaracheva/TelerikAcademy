namespace Exam
{
    using System;
    using System.Linq;
    using System.Text;

    public class MathProblemSolver
    {
        public static void Main()
        {
            int numericalSystem = 19;
            int divisor = 97;
            char[] numbersAsLetters = FillNumbers(numericalSystem, divisor);
            string[] input = Console.ReadLine().Split(' ');
            long result = TransformInput(input, divisor, numericalSystem);
            StringBuilder inputs = new StringBuilder();

            if (input.Length == 1)
            {
                inputs.Append(input[0]);
                Console.WriteLine("{0} = {1}", inputs, result);
            }
            else
            {
                string converted = ConvertToSystem(result, numbersAsLetters, numericalSystem);
                Console.WriteLine("{0} = {1}", converted, result);
            }
        }

        private static long TransformInput(string[] input, int divisor, int numSystem)
        {
            long result = 0;
            for (int j = 0; j < input.Length; j++)
            {
                long power = 1;
                long currentResult = 0;
                for (int i = input[j].Length - 1; i >= 0; i--)
                {
                    int index = input[j][i] - divisor;
                    currentResult += index * power;
                    power *= numSystem;
                }

                result += currentResult;
            }

            return result;
        }

        private static string ConvertToSystem(long result, char[] letters, int numSystem)
        {
            StringBuilder output = new StringBuilder();

            if (result == 0)
            {
                return output.Append(letters[0]).ToString();
            }

            while (result > 0)
            {
                output.Insert(0, letters[(int)(result % numSystem)]);
                result /= numSystem;
            }

            return output.ToString();
        }

        private static char[] FillNumbers(int numSystem, int divisor)
        {
            char[] numbersAsLetters = new char[numSystem];

            for (char i = 'a'; i <= 's'; i++)
            {
                numbersAsLetters[i - divisor] = i;
            }

            return numbersAsLetters;
        }
    }
}
