using System;
using System.Linq;

class SolvePatterns
{
    static int maxSum = 0;

    static void Main()
    {
        var matrix = ReadInput();

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 4; col++)
            {
                CheckPattern(matrix, row, col);
            }
        }

        if (maxSum != 0)
        {
            Console.WriteLine("YES {0}", maxSum);
        }
        else
        {
            Console.WriteLine("NO {0}", SumDiagonal(matrix));
        }
    }

    private static int SumDiagonal(int[,] matrix)
    {
        int sum = 0;
        int col = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            sum += matrix[row, col];
            col++;
        }


        return sum;
    }

    static void CheckPattern(int[,] matrix, int row, int col)
    {
        int number = matrix[row, col];
        int sum = 0;

        if (matrix[row, col + 1] == number + 1 && matrix[row, col + 2] == number + 2 &&
            matrix[row + 1, col + 2] == number + 3 &&
            matrix[row + 2, col + 2] == number + 4 && matrix[row + 2, col + 3] == number + 5 && matrix[row + 2, col + 4] == number + 6)
        {
            for (int i = 0; i <= 6; i++)
            {
                sum += (number + i);
            }

            if (sum > maxSum)
            {
                maxSum = sum;
            }
        }
    }

    private static int[,] ReadInput()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = line[col];
            }
        }

        return matrix;
    }
}

