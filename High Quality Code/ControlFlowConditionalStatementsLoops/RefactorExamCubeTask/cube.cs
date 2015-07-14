namespace RefactorExamCubeTask
{
    using System;

    public class Cube
    {
        private static int row;
        private static int col;

        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = FillMatrix((size * 2) - 1);
            row = matrix.GetLength(0) - 1;
            col = 0;
            matrix = DrawFrontBorder(matrix, size);

            col = 0;
            matrix = DrawBackBorder(matrix, size);

            row = 1;
            col = size - 1;
            matrix = DrawDashes(matrix, size);

            row = 2;
            col = matrix.GetLength(1) - 2;
            matrix = DrawX(matrix, size);

            PrintMatrix(matrix);
        }

        private static char[,] DrawX(char[,] matrix, int size)
        {
            for (int j = col; j >= col - (size - 3); j--)
            {
                for (int i = row; i < row + size - 2; i++)
                {
                    matrix[i, j] = 'X';
                }

                row++;
            }

            return matrix;
        }

        private static char[,] DrawDashes(char[,] matrix, int size)
        {
            for (int i = row; i < row + size - 2; i++)
            {
                for (int j = col; j < col + size - 2; j++)
                {
                    matrix[i, j] = '/';
                }

                col--;
            }

            return matrix;
        }

        private static char[,] DrawBackBorder(char[,] matrix, int size)
        {
            while (row >= 0)
            {
                matrix[row, col] = ':';
                matrix[row, col + size - 1] = ':';
                row--;
                col++;
            }

            row++;
            col--;
            while (col <= matrix.GetLength(1) - 1)
            {
                matrix[row, col] = ':';
                col++;
            }

            col--;
            while (row <= size - 1)
            {
                matrix[row, col] = ':';
                row++;
            }

            col = matrix.GetLength(1) - 2;

            while (row < (size * 2) - 1)
            {
                matrix[row, col] = ':';
                col--;
                row++;
            }

            return matrix;
        }

        private static char[,] DrawFrontBorder(char[,] matrix, int size)
        {
            for (int i = row; i >= size - 1; i--)
            {
                matrix[i, col] = ':';
                matrix[i, size - 1] = ':';
                row--;
            }

            row++;

            for (int i = 1; i < size; i++)
            {
                matrix[matrix.GetLength(0) - 1, i] = ':';
                matrix[row, i] = ':';
            }

            return matrix;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static char[,] FillMatrix(int p)
        {
            char[,] matrix = new char[p, p];

            for (int row = 0; row < p; row++)
            {
                for (int col = 0; col < p; col++)
                {
                    matrix[row, col] = ' ';
                }
            }

            return matrix;
        }
    }
}
