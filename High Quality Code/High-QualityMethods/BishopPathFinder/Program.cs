namespace BishopPathFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolveBishopPathFinder
    {
        public static void Main()
        {
            int[,] board = FillBoard();
            bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];
            int moves = int.Parse(Console.ReadLine());
            List<string> commands = FillMoves(moves);
            int row = board.GetLength(0) - 1;
            int col = 0;
            long sum = 0;

            for (int i = 0; i < commands.Count; i++)
            {
                string[] current = commands[i].Split(' ');
                string direction = current[0];
                int move = int.Parse(current[1]);

                for (int j = 0; j < move - 1; j++)
                {
                    sum += SumDirection(board, ref row, ref col, direction, visited);
                }
            }

            Console.WriteLine(sum);
        }

        private static int SumDirection(int[,] matrix, ref int row, ref int col, string direction, bool[,] visited)
        {
            if (direction == "UR" || direction == "RU")
            {
                if (row - 1 >= 0 && (col + 1 < matrix.GetLength(1)))
                {
                    row--;
                    col++;
                }
            }
            else if (direction == "UL" || direction == "LU")
            {
                if (row - 1 >= 0 && col - 1 >= 0)
                {
                    row--;
                    col--;
                }
            }
            else if (direction == "DR" || direction == "RD")
            {
                if (row + 1 < matrix.GetLength(0) && (col + 1 < matrix.GetLength(1)))
                {
                    row++;
                    col++;
                }
            }
            else if (direction == "DL" || direction == "LD")
            {
                if (row + 1 < matrix.GetLength(0) && col - 1 >= 0)
                {
                    row++;
                    col--;
                }
            }

            if (!visited[row, col])
            {
                visited[row, col] = true;
                return matrix[row, col];
            }
            else
            {
                return 0;
            }
        }

        private static List<string> FillMoves(int move)
        {
            List<string> commands = new List<string>();
            for (int i = 0; i < move; i++)
            {
                commands.Add(Console.ReadLine());
            }

            return commands;
        }

        private static int[,] FillBoard()
        {
            int[] dimmenssions = Console.ReadLine()
                                        .Split(' ')
                                        .Select(int.Parse)
                                        .ToArray();

            int row = dimmenssions[0];
            int col = dimmenssions[1];
            int[,] matrix = new int[row, col];
            row--;

            int value = 0;

            while (row >= 0)
            {
                int currentRow = row;
                int currentCol = 0;
                while (currentRow < matrix.GetLength(0) && currentCol < matrix.GetLength(1))
                {
                    matrix[currentRow, currentCol] = value;
                    currentRow++;
                    currentCol++;
                }

                row--;
                value += 3;
            }

            col = 1;
            while (col < matrix.GetLength(1))
            {
                int currentRow = 0;
                int currentCol = col;

                while (currentCol < matrix.GetLength(1) && currentRow < matrix.GetLength(0))
                {
                    matrix[currentRow, currentCol] = value;
                    currentRow++;
                    currentCol++;
                }

                value += 3;
                col++;
            }

            return matrix;
        }
    }
}
