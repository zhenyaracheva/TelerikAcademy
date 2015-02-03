using System;

class PrintDiamondTrolls
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int width = n * 2 + 1;
        int height = 6 + ((n - 3) / 2) * 3;
        char[,] diamond = FillDiamonWithDots(width, height);
        int row = diamond.GetLength(0) - 1;
        int col = n;

        for (int currentRow = 0; currentRow < diamond.GetLength(0); currentRow++)
        {
            diamond[currentRow, n] = '*';
        }

        while (col >= 0)
        {
            diamond[row, col] = '*';
            diamond[row, diamond.GetLength(1) - col - 1] = '*';
            col--;
            row--;
        }

        col++;
        row++;

        for (int currentCol = 0; currentCol < diamond.GetLength(1); currentCol++)
        {
            diamond[row, currentCol] = '*';
        }

        while (row >= 0)
        {
            diamond[row, col] = '*';
            diamond[row, diamond.GetLength(1) - col - 1] = '*';
            row--;
            col++;
        }

        row++;
        col--;

        while (n > 0)
        {
            diamond[row, col] = '*';
            col++;
            n--;
        }

        PrintDiamond(diamond);
    }

    private static char[,] FillDiamonWithDots(int width, int height)
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

    private static void PrintDiamond(char[,] diamond)
    {
        for (int row = 0; row < diamond.GetLength(0); row++)
        {
            for (int col = 0; col < diamond.GetLength(1); col++)
            {
                Console.Write(diamond[row, col]);
            }
            Console.WriteLine();
        }
    }
}

