//Problem 1. Fill the matrix

//Write a program that fills and prints a matrix of size (n, n) as shown below:
//Example for n=4:

//a)	
//1	5 9	 13
//2	6 10 14
//3	7 11 15
//4	8 12 16
//b)
//1	8 9	 16
//2	7 10 15
//3	6 11 14
//4	5 12 13
//c)
//7	11 14 16
//4	8  12 15
//2	5  9  13
//1	3  6  10
//d)
//1	12 11 10
//2	13 16 9
//3	14 15 8
//4	5  6  7

using System;

class PrintMatrix
{
    static void Main()
    {
        Console.Write("Please, enter matrix size: ");
        int n = CheckValidN();
        int[,] matrix = new int[n, n];

        FillMatrixA(matrix);
        Console.WriteLine();

        FillMatrixB(matrix);
        Console.WriteLine();

        FIllMatrixC(matrix);
        Console.WriteLine();

        FillMatrixD(new int[n,n]);

    }

    private static void FillMatrixD(int[,] matrix)
    {
        int row = 0;
        int col = 0;
        string direction = "down";

        for (int i = 1; i <= matrix.GetLength(0) * matrix.GetLength(1); i++)
        {
            if (direction == "down")
            {
                matrix[row, col] = i;

                if (row + 1 <= matrix.GetLength(0) - 1 && matrix[row + 1, col] == 0)
                {
                    row++;
                }
                else
                {
                    direction = "right";
                    col++;
                }
            }
            else if (direction == "right")
            {
                matrix[row, col] = i;

                if (col + 1 <= matrix.GetLength(1) - 1 && matrix[row, col + 1] == 0)
                {
                    col++;
                }
                else
                {
                    direction = "up";
                    row--;
                }
            }
            else if (direction == "up")
            {
                matrix[row, col] = i;

                if (row - 1 >= 0 && matrix[row - 1, col] == 0)
                {
                    row--;
                }
                else
                {
                    direction = "left";
                    col--;
                }
            }
            else if (direction == "left")
            {
                matrix[row, col] = i;

                if (col - 1 >= 0 && matrix[row, col-1] == 0)
                {
                    col--;
                }
                else
                {
                    direction = "down";
                    row++;
                }
            }
        }

        Print(matrix);
    }

    private static void FIllMatrixC(int[,] matrix)
    {
        int row = matrix.GetLength(0) - 1;
        int col = 0;
        int index = 1;

        for (int i = 1; i <= matrix.GetLength(0); i++)
        {
            do
            {
                if (row < 0) row = 0;
                matrix[row, col] = index;
                index++;
                row++;
                col++;
            } while (row < matrix.GetLength(0));

            row -= col + 1;
            col = 0;
        }

        row = 0;
        col = 1;

        for (int i = 1; i <= matrix.GetLength(0) - 1; i++)
        {
            do
            {
                matrix[row, col] = index;
                index++;
                row++;
                col++;
            } while (col < matrix.GetLength(0));

            col -= row - 1;
            row = 0;
        }

        Print(matrix);
    }

    private static void FillMatrixB(int[,] matrix)
    {
        bool drawDown = true;
        int row = 0;
        int col = 0;

        for (int index = 1; index <= matrix.GetLength(0) * matrix.GetLength(1); index++)
        {
            if (drawDown)
            {
                matrix[row, col] = index;
                row++;

                if (row >= matrix.GetLength(0))
                {
                    col++;
                    row--;
                    drawDown = false;
                }

            }
            else
            {
                matrix[row, col] = index;
                row--;

                if (row < 0)
                {
                    col++;
                    row++;
                    drawDown = true;
                }

            }
        }

        Print(matrix);
    }

    private static void FillMatrixA(int[,] matrix)
    {
        int index = 1;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[col, row] = index;
                index++;
            }
        }

        Print(matrix);
    }



    private static void Print(int[,] matrix)
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

    private static int CheckValidN()
    {
        int n = int.Parse(Console.ReadLine());

        while (n <= 0)
        {
            Console.Write("Size must be bigger than 0! Try again: ");
            n = int.Parse(Console.ReadLine());
        }

        return n;
    }
}

