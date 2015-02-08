//Problem 7.* Largest area in matrix

//Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.
//Example:

//      matrix	            result
//1	 3  2  2  2	 4            13
//3	 3  3  2  4	 4
//4	 3  1  2  3	 3
//4	 3  1  3  3	 1
//4	 3  3  3  1	 1

using System;

class FindLargestAreaInMatrix
{
    static bool[,] visited;
    static int maxCount = 0;

    static void Main()
    {
        Console.Write("Please, enter maxtix width and heigth(separate by space): ");
        string[] matrixSize = CheckMatrixSize();
        int heigth = int.Parse(matrixSize[0]);
        int width = int.Parse(matrixSize[1]);
        int[,] matrix = FillMatrix(heigth, width);
        visited = new bool[heigth, width];
        int counter = 1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                FindLongNeighbours(i, i, matrix, counter);
            }
        }

        Console.Write("The largest area of equal neighbour elements is: ");
        Console.WriteLine(maxCount);
    }

    private static void FindLongNeighbours(int row, int col, int[,] matrix, int counter)
    {
        int currerntNumber = matrix[row, col];
        visited[row, col] = true;

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (InMatrix(i, j, matrix))
                {
                    if (matrix[i, j] == currerntNumber && !visited[i, j])
                    {
                        counter++;
                        visited[i, j] = true;
                        FindLongNeighbours(i, j, matrix, counter);
                        counter--;
                        visited[i, j] = false;
                    }
                    else
                    {
                        if (counter > maxCount)
                        {
                            maxCount = counter;
                        }
                    }
                }
            }
        }
    }

    private static bool InMatrix(int row, int col, int[,] matrix)
    {
        if (row < 0 || row >= matrix.GetLength(0))
        {
            return false;
        }

        if (col < 0 || col >= matrix.GetLength(1))
        {
            return false;
        }

        return true;
    }

    private static int[,] FillMatrix(int height, int width)
    {
        int[,] matrix = new int[height, width];
        Console.WriteLine("Please, enter {0} lines with {1} numbers separate by space:", height, width);

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] line = CheckLine(width);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = int.Parse(line[col]);
            }
        }

        return matrix;
    }

    private static string[] CheckLine(int width)
    {
        string[] line = Console.ReadLine().Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        while (line.Length != width)
        {
            Console.Write("Line must have {0} numbers! Try again: ", width);
            line = Console.ReadLine().Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return line;
    }

    private static string[] CheckMatrixSize()
    {
        string[] size = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        while (size.Length != 2)
        {
            Console.Write("You must enter only 2 numbers separate by space! Try again: ");
            size = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        return size;
    }
}

