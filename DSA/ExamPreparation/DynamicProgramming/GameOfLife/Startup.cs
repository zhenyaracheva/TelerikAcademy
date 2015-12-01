namespace GameOfLife
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static int count;

        public static void Main()
        {
            var generations = int.Parse(Console.ReadLine());
            var matrixSize = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var matrix = new int[int.Parse(matrixSize[0]), int.Parse(matrixSize[1])];
            count = 0;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var current = line[col];

                    if (current == 1)
                    {
                        count++;
                    }

                    matrix[row, col] = current;
                }
            }

            for (int gen = 0; gen < generations; gen++)
            {
                matrix = TrasformGeneration(matrix);
            }
            
            Console.WriteLine(count);
        }
        
        private static int[,] TrasformGeneration(int[,] matrix)
        {
            var transformation = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var neighbours = CountNeightbours(matrix, row, col);

                    if (matrix[row, col] == 0)
                    {
                        if (neighbours == 3)
                        {
                            transformation[row, col] = 1;
                            count++;
                        }
                        else
                        {
                            transformation[row, col] = 0;
                        }
                    }
                    else
                    {
                        if (neighbours == 2 || neighbours == 3)
                        {
                            transformation[row, col] = 1;
                        }
                        else
                        {
                            transformation[row, col] = 0;
                            count--;
                        }
                    }
                }
            }

            return transformation;
        }

        private static int CountNeightbours(int[,] matrix, int row, int col)
        {
            var count = 0;

            for (int i = row - 1; i <= row + 1; i++)
            {
                if (i >= 0 && i < matrix.GetLength(0))
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (j >= 0 && j < matrix.GetLength(1) &&
                            matrix[i, j] == 1)
                        {
                            if (i != row || j != col)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }
    }
}
