//Problem 19.** Spiral Matrix

//Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a 
//matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.
//Examples:

//n = 2   matrix      n = 3   matrix      n = 4   matrix
//        1 2                 1 2 3               1  2  3  4
//        4 3                 8 9 4               12 13 14 5
//                            7 6 5               11 16 15 6
//                                                10 9  8  7

using System;

class PrintSpiralMatrix
{
    static void Main()
    {
        Console.Write("Please, enter a positive integer number n (1 ≤ n ≤ 20): ");
        int n = CheckNumber();
        int[,] matrix = new int[n, n];

        string direction = "right";
        int row = 0;
        int col = 0;

        for (int i = 1; i <= n * n; i++)
        {
            if (direction == "right")
            {
                matrix[row, col] = i;

                if ((col == matrix.GetLength(0) - 1) || (matrix[row, col + 1] != 0))
                {
                    direction = "down";
                    row++;
                }
                else
                {
                    col++;
                }
            }
            else if (direction == "down")
            {
                matrix[row, col] = i;

                if ((row == matrix.GetLength(1) - 1) || matrix[row + 1, col] != 0)
                {
                    direction = "left";
                    col--;
                }
                else
                {
                    row++;
                }
            }
            else if (direction == "left")
            {
                matrix[row, col] = i;

                if (col == 0 || matrix[row, col - 1] != 0)
                {
                    direction = "up";
                    row--;
                }
                else
                {
                    col--;
                }
            }
            else if (direction == "up")
            {
                matrix[row, col] = i;

                if (row == 0 || matrix[row - 1, col] != 0)
                {
                    direction = "right";
                    col++;
                }
                else
                {
                    row--;
                }
            }

        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,3} ", matrix[i, j]);
            }

            Console.WriteLine();
        }
    }

    private static int CheckNumber()
    {
        int n = int.Parse(Console.ReadLine());

        while (n < 1 || n > 20)
        {
            Console.Write("Invalid number! Number must be in range 1-20! Try again: ");
            n = int.Parse(Console.ReadLine());
        }

        return n;
    }
}

