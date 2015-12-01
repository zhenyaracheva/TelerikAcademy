namespace Brackets
{
    using System;

    public class Startup
    {
        public static void Main()
        {

            var brackets = Console.ReadLine();

            var matrix = new long[brackets.Length + 1, brackets.Length + 1];
            matrix[0, 0] = 1;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                var symbol = brackets[row - 1];

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbol == '(')
                    {
                        if (col - 1 >= 0)
                        {
                            matrix[row, col] = matrix[row - 1, col - 1];
                        }
                    }
                    else if (symbol == ')')
                    {
                        if (col + 1 < matrix.GetLength(1))
                        {
                            matrix[row, col] = matrix[row - 1, col + 1];
                        }
                    }
                    else
                    {
                        if (col - 1 >= 0)
                        {
                            matrix[row, col] += matrix[row - 1, col - 1];
                        }

                        if (col + 1 < matrix.GetLength(1))
                        {
                            matrix[row, col] += matrix[row - 1, col + 1];
                        }
                    }
                }
            }

            Console.WriteLine(matrix[brackets.Length, 0]);
        }
    }
}
