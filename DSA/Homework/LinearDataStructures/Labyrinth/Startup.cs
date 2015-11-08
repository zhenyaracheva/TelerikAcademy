namespace Labyrinth
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var matrix = CreateMatrix(6, 6);
            FindAllPaths(matrix, 2, 0, 1);
            FillUnreachablePath(matrix);
            PrintMatrix(matrix);
        }

        private static void FillUnreachablePath(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == null)
                    {
                        matrix[row, col] = "u";
                    }
                }
            }
        }

        private static void FindAllPaths(string[,] matrix, int startRow, int startCol, int number)
        {
            if (startRow >= matrix.GetLength(0) || startCol >= matrix.GetLength(1) ||
                matrix[startRow, startCol] == "x")
            {
                return;
            }

            matrix[startRow, startCol] = number.ToString();

            int nextNumber;
            if (startCol + 1 < matrix.GetLength(1) && int.TryParse(matrix[startRow, startCol + 1], out nextNumber) &&
                (int.Parse(matrix[startRow, startCol + 1]) == 0 || int.Parse(matrix[startRow, startCol + 1]) > number))
            {
                FindAllPaths(matrix, startRow, startCol + 1, number + 1);
            }

            if (startRow + 1 < matrix.GetLength(0) && int.TryParse(matrix[startRow + 1, startCol], out nextNumber) &&
                (int.Parse(matrix[startRow + 1, startCol]) == 0 || int.Parse(matrix[startRow + 1, startCol]) > number))
            {
                FindAllPaths(matrix, startRow + 1, startCol, number + 1);
            }

            if (startRow - 1 >= 0 && int.TryParse(matrix[startRow - 1, startCol], out nextNumber) &&
                (int.Parse(matrix[startRow - 1, startCol]) == 0 || int.Parse(matrix[startRow - 1, startCol]) > number))
            {
                FindAllPaths(matrix, startRow - 1, startCol, number + 1);
            }

            if (startCol - 1 >= 0 && int.TryParse(matrix[startRow, startCol - 1], out nextNumber) &&
                (int.Parse(matrix[startRow, startCol - 1]) == 0 || int.Parse(matrix[startRow, startCol - 1]) > number))
            {
                FindAllPaths(matrix, startRow, startCol - 1, number + 1);
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var symbol = matrix[i, j] == null ? " " : matrix[i, j];
                    Console.Write("{0,3}", symbol);
                }

                Console.WriteLine();
            }
        }

        private static string[,] CreateMatrix(int rows, int cols)
        {
            var matrix = new string[,]
                 {
                    { "0", "0", "0", "x", "0", "x"},
                    { "0", "x", "0", "x", "0", "x"},
                    { "0", "*", "x", "0", "x", "0"},
                    { "0", "x", "0", "0", "0", "0"},
                    { "0", "0", "0", "x", "x", "0"},
                    { "0", "0", "0", "x", "0", "x"}
                };


            //matrix[0, 3] = "X";
            //matrix[0, 5] = "X";
            //matrix[1, 1] = "X";
            //matrix[1, 3] = "X";
            //matrix[1, 5] = "X";
            //matrix[2, 1] = "*";
            //matrix[2, 2] = "X";
            //matrix[2, 2] = "X";
            //matrix[2, 4] = "X";
            //matrix[3, 1] = "X";
            //matrix[2, 2] = "X";
            //matrix[4, 3] = "X";
            //matrix[4, 4] = "X";
            //matrix[5, 3] = "X";
            //matrix[5, 5] = "X";

            return matrix;
        }
    }
}
