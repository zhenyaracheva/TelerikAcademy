//Problem 2. Maximal sum

//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class FindMaxSum
{
    const int smallMatrixSize = 3;
    static void Main()
    {
        int[,] matrix = FillMatrix();
        int maxSum = 0;
        int[,] maxMatrix = new int[smallMatrixSize, smallMatrixSize];

        for (int row = 1; row <= matrix.GetLength(0) - 2; row++)
        {
            for (int col = 1; col <= matrix.GetLength(1) - 2; col++)
            {
                int[,] currerntSmallMatrix = FindSmallMatrix(row, col, matrix);
                int currerntSmallMatrixSum = MatrixSum(currerntSmallMatrix);

                if (maxSum < currerntSmallMatrixSum)
                {
                    maxSum = currerntSmallMatrixSum;

                    for (int i = 0; i < currerntSmallMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < currerntSmallMatrix.GetLength(1); j++)
                        {
                            maxMatrix[i, j] = currerntSmallMatrix[i, j];
                        }
                    }
                }

            }
        }

        Console.WriteLine("Max matrix 3x3 is:");
        PrintMtrix(maxMatrix);

    }

    private static void PrintMtrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,3} ", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static int MatrixSum(int[,] matrix)
    {
        int sum = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum += matrix[row, col];
            }
        }

        return sum;
    }

    private static int[,] FindSmallMatrix(int row, int col, int[,] matrix)
    {
        int[,] smallMatrix = new int[smallMatrixSize, smallMatrixSize];

        for (int i = row - 1, sRow = 0; i <= row + 1; i++, sRow++)
        {
            for (int j = col - 1, sCol = 0; j <= col + 1; j++, sCol++)
            {
                smallMatrix[sRow, sCol] = matrix[i, j];
            }
        }

        return smallMatrix;
    }

    private static int[,] FillMatrix()
    {
        Console.Write("Please, enter matrix width: ");
        int n = CheckValidNumber();

        Console.Write("Please, enter matrix heigth: ");
        int m = CheckValidNumber();
        int[,] matrix = new int[n, m];

        Console.WriteLine("Please, enter {0} lines with {1} numbers (separated by space):", n, m);
        for (int i = 0; i < n; i++)
        {
            string[] currerntLine = CheckLine(m);


            for (int j = 0; j < currerntLine.Length; j++)
            {
                matrix[i, j] = int.Parse(currerntLine[j]);
            }
        }

        return matrix;
    }

    private static string[] CheckLine(int width)
    {
        string[] line = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        while (line.Length != width)
        {
            Console.Write("Line must have {0} numbers! Try again: ");
            line = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return line;
    }

    private static int CheckValidNumber()
    {
        int n = int.Parse(Console.ReadLine());

        while (n <= 2)
        {
            Console.Write("Number must be bigger than 2: try again: ");
            n = int.Parse(Console.ReadLine());
        }

        return n;
    }


}
