using System;
using System.Linq;

class SolveDogeCoin
{
    static void Main()
    {
        int[,] matrix = ReadInput();

        for (int row = 0; row < 1; row++)
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] += matrix[row, col - 1];
            }
        }

        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < 1; col++)
            {
                matrix[row, col] += matrix[row - 1, col];
            }
        }

        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {

                matrix[row, col] = matrix[row, col] + Math.Max(matrix[row - 1, col], matrix[row, col - 1]);

            }
        }

        Console.WriteLine(matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]);
    }

    private static int[,] ReadInput()
    {
        int[] size = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[,] matrix = new int[size[0], size[1]];
        int coins = int.Parse(Console.ReadLine());

        for (int i = 0; i < coins; i++)
        {
            int[] coordinates = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            matrix[coordinates[0], coordinates[1]]++;
        }

        return matrix;
    }

}
