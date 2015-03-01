using System;
using System.Linq;
using System.Numerics;

class SolveHelpDoge
{
    static void Main()
    {
        var matrix = ReadInput();

        BigInteger[,] path = new BigInteger[matrix.GetLength(0), matrix.GetLength(1)];
        path[0, 0] = 1;

        if (matrix[0, 0] == 'F')
        {
            Console.WriteLine(path[0, 0]);
            return;
        }

        for (int i = 1; i < matrix.GetLength(1); i++)
        {
            if (matrix[0, i] != 'E' && matrix[0, i] != 'F')
            {
                path[0, i] += path[0, i - 1];
            }
            else if (matrix[0, i] == 'F')
            {
                Console.WriteLine(path[0, i] += path[0, i - 1]);
                return;
            }
        }

        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, 0] != 'E' && matrix[i, 0] != 'F')
            {
                path[i, 0] += path[i - 1, 0];
            }
            else if (matrix[i, 0] == 'F')
            {
                Console.WriteLine(path[i, 0] += path[i - 1, 0]);
                return;
            }
        }

        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] != 'E' && matrix[row, col] != 'F')
                {
                    path[row, col] = path[row - 1, col] + path[row, col - 1];
                }

                if (matrix[row, col] == 'F')
                {
                    Console.WriteLine(path[row - 1, col] + path[row, col - 1]);
                }
            }
        }
    }

    private static char[,] ReadInput()
    {
        int[] size = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        char[,] matrix = new char[size[0], size[1]];

        int[] foodPosition = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        matrix[foodPosition[0], foodPosition[1]] = 'F';

        int enemies = int.Parse(Console.ReadLine());
        for (int i = 0; i < enemies; i++)
        {
            int[] current = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            matrix[current[0], current[1]] = 'E';
        }

        return matrix;
    }
}

