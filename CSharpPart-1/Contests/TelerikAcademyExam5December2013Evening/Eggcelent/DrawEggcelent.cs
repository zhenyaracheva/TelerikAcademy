using System;

class DrawEggcelent
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int matriWidth = 3 * n + 1;
        int matrixHeight = 2 * n;
        char[,] matrix = DraqMatrixDots(matrixHeight, matriWidth);

        int row = n / 2;
        int col = 1;

        for (int i = row; i < row + n; i++)
        {
            matrix[i, col] = '*';
            matrix[i, matrix.GetLength(1) - col - 1] = '*';
        }

        while (row >= 0)
        {
            matrix[row, col] = '*';
            matrix[row, matrix.GetLength(1) - col - 1] = '*';
            matrix[matrix.GetLength(0) - row - 1, col] = '*';
            matrix[matrix.GetLength(0) - row - 1, matrix.GetLength(1) - col - 1] = '*';

            row--;
            col += 2;
        }

        row++;
        col -= 2;

        for (int i = col; i < col + n - 1; i++)
        {
            matrix[row, i] = '*';
            matrix[matrix.GetLength(0) - 1, i] = '*';
        }

        row = n - 1;
        col = 2;

        matrix = SetCrack(row, col, matrix);
        matrix = SetCrack(row + 1, col + 1, matrix);

        PrintMatrix(matrix);
    }

    private static char[,] SetCrack(int row, int col, char[,] matrix)
    {
        for (int i = col; i < matrix.GetLength(1) - 2; i += 2)
        {
            matrix[row, i] = '@';
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

    private static char[,] DraqMatrixDots(int height, int width)
    {
        char[,] matrix = new char[height, width];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = '.';
            }
        }

        return matrix;
    }
}

