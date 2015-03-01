using System;
using System.Linq;

class SolveDigits
{
    static int count = 0;

    static void Main()
    {
        char[,] matrix = ReadInput();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                if (matrix[row, col] == '1')
                {
                    CheckOne(matrix, row, col);
                }
                else if (matrix[row, col] == '2')
                {
                    CheckTwo(matrix, row, col);
                }
                else if (matrix[row, col] == '3')
                {
                    ChackThree(matrix, row, col);
                }
                else if (matrix[row, col] == '4')
                {
                    CheckFour(matrix, row, col);
                }
                else if (matrix[row, col] == '5')
                {
                    CheckFive(matrix, row, col);
                }
                else if (matrix[row, col] == '6')
                {
                    CheckSix(matrix, row, col);
                }
                else if (matrix[row, col] == '7')
                {
                    CheckSeven(matrix, row, col);
                }
                else if (matrix[row, col] == '8')
                {
                    CheckEight(matrix, row, col);
                }
                else if (matrix[row, col] == '9')
                {
                    CheckNine(matrix, row, col);
                }
            }
        }

        Console.WriteLine(count);

    }

    private static void CheckNine(char[,] matrix, int row, int col)
    {
        if (row + 4 < matrix.GetLength(0))
        {
            if (matrix[row, col + 1] == '9' && matrix[row, col + 2] == '9' &&
                matrix[row + 1, col] == '9' && matrix[row + 1, col + 2] == '9' &&
                matrix[row + 2, col + 1] == '9' && matrix[row + 2, col + 2] == '9' &&
                matrix[row + 3, col + 2] == '9' &&
                matrix[row + 4, col] == '9' && matrix[row + 4, col + 1] == '9' && matrix[row + 4, col + 2] == '9')
            {
                count += 9;
            }
        }
    }

    private static void CheckSeven(char[,] matrix, int row, int col)
    {
        if (row + 4 < matrix.GetLength(0))
        {
            if (matrix[row, col + 1] == '7' && matrix[row, col + 2] == '7' && matrix[row + 1, col + 2] == '7' &&
                matrix[row + 2, col + 1] == '7' && matrix[row + 3, col + 1] == '7' && matrix[row + 4, col + 1] == '7')
            {
                count += 7;
            }
        }
    }

    private static void CheckEight(char[,] matrix, int row, int col)
    {
        if (row + 4 < matrix.GetLength(0))
        {
            if (matrix[row, col + 1] == '8' && matrix[row, col + 2] == '8' &&
                matrix[row + 1, col] == '8' && matrix[row + 1, col + 2] == '8' &&
                matrix[row + 2, col + 1] == '8' &&
                matrix[row + 3, col] == '8' && matrix[row + 3, col + 2] == '8' &&
                matrix[row + 4, col] == '8' && matrix[row + 4, col + 1] == '8' && matrix[row + 4, col + 2] == '8')
            {
                count += 8;
            }
        }
    }

    private static void CheckSix(char[,] matrix, int row, int col)
    {
        if (row + 4 < matrix.GetLength(0))
        {
            if (matrix[row, col + 1] == '6' && matrix[row, col + 2] == '6' && matrix[row + 1, col] == '6' &&
                matrix[row + 2, col] == '6' && matrix[row + 2, col + 1] == '6' && matrix[row + 2, col + 2] == '6' &&
                matrix[row + 3, col] == '6' && matrix[row + 3, col + 2] == '6' &&
                matrix[row + 4, col] == '6' && matrix[row + 4, col + 1] == '6' && matrix[row + 4, col + 2] == '6')
            {
                count += 6;
            }
        }
    }

    private static void CheckFive(char[,] matrix, int row, int col)
    {
        if (row + 4 < matrix.GetLength(0))
        {
            if (matrix[row, col + 1] == '5' && matrix[row, col + 2] == '5' && matrix[row + 1, col] == '5' &&
                matrix[row + 2, col] == '5' && matrix[row + 2, col + 1] == '5' && matrix[row + 2, col + 2] == '5' &&
                matrix[row + 3, col + 2] == '5' && matrix[row + 4, col] == '5' && matrix[row + 4, col + 1] == '5' &&
                matrix[row + 4, col + 2] == '5')
            {
                count += 5;
            }
        }
    }

    private static void CheckFour(char[,] matrix, int row, int col)
    {
        if (row + 4 < matrix.GetLength(0))
        {
            if (matrix[row, col + 2] == '4' && matrix[row + 1, col + 2] == '4' && matrix[row + 1, col] == '4' &&
                matrix[row + 2, col] == '4' && matrix[row + 2, col + 1] == '4' && matrix[row + 2, col + 2] == '4' &&
                matrix[row + 3, col + 2] == '4' && matrix[row + 4, col + 2] == '4')
            {
                count += 4;
            }
        }
    }

    private static void ChackThree(char[,] matrix, int row, int col)
    {
        if (row + 4 < matrix.GetLength(0))
        {
            if (matrix[row, col + 1] == '3' && matrix[row, col + 2] == '3' && matrix[row + 1, col + 2] == '3' &&
                matrix[row + 2, col + 1] == '3' && matrix[row + 2, col + 2] == '3' && matrix[row + 3, col + 2] == '3' &&
                matrix[row + 4, col] == '3' && matrix[row + 4, col + 1] == '3' && matrix[row + 4, col + 2] == '3')
            {
                count += 3;
            }
        }
    }

    static void CheckTwo(char[,] matrix, int row, int col)
    {
        if (row - 1 >= 0 && row + 3 < matrix.GetLength(0))
        {
            if (matrix[row - 1, col + 1] == '2' && matrix[row, col + 2] == '2' && matrix[row + 1, col + 2] == '2' &&
                matrix[row + 2, col + 1] == '2' && matrix[row + 3, col] == '2' && matrix[row + 3, col + 1] == '2' &&
                matrix[row + 3, col + 2] == '2')
            {
                count += 2;
            }
        }
    }

    static void CheckOne(char[,] matrix, int row, int col)
    {
        if (row - 2 >= 0 && row + 2 < matrix.GetLength(0))
        {
            if (matrix[row - 1, col + 1] == '1' && matrix[row - 2, col + 2] == '1' && matrix[row - 1, col + 2] == '1' &&
            matrix[row, col + 2] == '1' && matrix[row + 1, col + 2] == '1' && matrix[row + 2, col + 2] == '1')
            {
                count += 1;
            }
        }
    }

    private static char[,] ReadInput()
    {
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];


        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = line[col];
            }
        }

        return matrix;
    }
}

