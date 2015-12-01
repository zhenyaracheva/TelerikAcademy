namespace Portals
{
    using System;

    public class Program
    {
        private static int maxPath = 0;

        public static void Main()
        {
            var startLocation = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var startRow = int.Parse(startLocation[0]);
            var startCol = int.Parse(startLocation[1]);

            var matrixSize = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(matrixSize[0]);
            var cols = int.Parse(matrixSize[1]);
            var matrix = new string[rows, cols];
            var visited = new bool[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var symbol = line[col];
                    matrix[row, col] = symbol;

                    if (symbol == "#")
                    {
                        visited[row, col] = true;
                    }
                }
            }

            FindPath(matrix, visited, startRow, startCol, 0);

            Console.WriteLine(maxPath);
        }

        private static void FindPath(string[,] matrix, bool[,] visited, int row, int col, int path)
        {
            if (path > maxPath)
            {
                maxPath = path;
            }

            if (visited[row, col])
            {
                return;
            }

            var power = int.Parse(matrix[row, col]);


            visited[row, col] = true;

            if (row + power < matrix.GetLength(0) && matrix[row + power, col] != "#")
            {
                path += power;
                FindPath(matrix, visited, row + power, col, path);
                path -= power;
            }

            if (row - power >= 0 && matrix[row - power, col] != "#")
            {
                path += power;
                FindPath(matrix, visited, row - power, col, path);
                path -= power;
            }

            if (col + power < matrix.GetLength(1) && matrix[row, col + power] != "#")
            {
                path += power;
                FindPath(matrix, visited, row, col + power, path);
                path -= power;
            }

            if (col - power >= 0 && matrix[row, col - power] != "#")
            {
                path += power;
                FindPath(matrix, visited, row, col - power, path);
                path -= power;
            }

            visited[row, col] = false;

        }
    }
}
