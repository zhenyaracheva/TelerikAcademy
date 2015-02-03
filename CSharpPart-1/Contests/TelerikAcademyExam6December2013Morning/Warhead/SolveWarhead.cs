using System;

class SolveWarhead
{
    public const int Height = 16;
    public const int Width = 16;

    static void Main()
    {
        char[,] matrix = matrix = FillMatrix();
        while (true)
        {
            string command = Console.ReadLine();

            if (command == "hover" || command == "operate")
            {

                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                if (command == "hover")
                {
                    if (matrix[row, col] == '1')
                    {
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.WriteLine("-");
                    }
                }
                else if (command == "operate")
                {
                    if (matrix[row, col] == '0')
                    {
                        if (CheckCapacitor(row, col, matrix))
                        {
                            matrix = ClearBomb(row, col, matrix);
                        }
                    }
                    else
                    {
                        Console.WriteLine("missed");
                        Console.WriteLine(CheckField(matrix));
                        Console.WriteLine("BOOM");
                        Environment.Exit(0);
                    }
                }
            }
            else if (command == "cut")
            {
                string color = Console.ReadLine();

                if (color == "red")
                {
                    int capacitorsLeftRed = CheckBlueRed(0, Width / 2, matrix);

                    if (capacitorsLeftRed == 0)
                    {
                        int capacitorsBlueSide = CheckBlueRed(Width / 2, Width, matrix);
                        Console.WriteLine(capacitorsBlueSide);
                        Console.WriteLine("disarmed");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine(capacitorsLeftRed);
                        Console.WriteLine("BOOM");
                        Environment.Exit(0);
                    }
                }
                else if (color == "blue")
                {
                    int capacitorsBlueSide = CheckBlueRed(Width / 2, Width, matrix);

                    if (capacitorsBlueSide == 0)
                    {
                        int capacitorsRedSide = CheckBlueRed(0, Width / 2, matrix);
                        Console.WriteLine(capacitorsRedSide);
                        Console.WriteLine("disarmed");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine(capacitorsBlueSide);
                        Console.WriteLine("BOOM");
                        Environment.Exit(0);

                    }
                }
            }
        }
    }

    private static int CheckBlueRed(int startCol, int endCol, char[,] matrix)
    {
        int counter = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = startCol; col < endCol; col++)
            {
                if (matrix[row, col] == '0' && CheckCapacitor(row, col, matrix))
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    private static int CheckField(char[,] matrix)
    {
        int counter = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == '0' && CheckCapacitor(row, col, matrix))
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    private static char[,] ClearBomb(int row, int col, char[,] matrix)
    {
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (matrix[i, j] == '1')
                {
                    matrix[i, j] = '0';
                }
            }
        }

        return matrix;
    }

    private static bool CheckCapacitor(int row, int col, char[,] matrix)
    {
        int counter = 0;

        if (matrix[row, col] == '0')
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (row - 1 >= 0 && row + 1 < matrix.GetLength(0) && col - 1 >= 0 && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[i, j] == '1')
                        {
                            counter++;
                        }
                    }
                }
            }

            if (counter == 8)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        else
        {
            return false;
        }
    }

    private static char[,] FillMatrix()
    {
        char[,] matrix = new char[Height, Width];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string line = Console.ReadLine();

            for (int col = 0; col < line.Length; col++)
            {
                matrix[row, col] = line[col];
            }
        }

        return matrix;
    }
}

