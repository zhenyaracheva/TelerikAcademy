//Problem 3. Sequence n matrix

//We are given a matrix of strings of size N x M. Sequences in the matrix we define as 
//sets of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.
//Example:

//matrix	            result		    matrix	        result
//ha  fifi  ho  hi      ha, ha, ha      s	qq	s       s, s, s
//fo  ha	hi	xx                      pp	pp	s
//xxx ho	ha	xx                      pp	qq	s


using System;
using System.Text;

class PrintLongSequence
{
    static string maxMember = string.Empty;
    static int maxCount = 1;
    static bool[,] visited;

    static void Main()
    {
        Console.Write("Please, enter maxtix width and heigth(separate by space): ");
        string[] matrixSize = CheckMatrixSize();
        int heigth = int.Parse(matrixSize[0]);
        int width = int.Parse(matrixSize[1]);
        string[,] matrix = FillStringMatrix(heigth, width);
        visited = new bool[heigth, width];
        int counter = 1;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                FindSequence(row, col, matrix, counter);
            }
        }

        PrintMaxSequence();

    }

    private static void PrintMaxSequence()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < maxCount; i++)
        {
            result.AppendFormat("{0}, ", maxMember);
        }

        result.Length-=2;
        Console.WriteLine("Max sequense is:");
        Console.WriteLine(result);
    }

    private static void FindSequence(int row, int col, string[,] matrix,int counter)
    {
        string member = matrix[row, col];
        visited[row, col] = true;

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col-1; j <= col + 1; j++)
            {
                if (InMatrix(i, j, matrix))
                {
                    if (matrix[i, j] == member && !visited[i,j])
                    {
                        counter++;
                        visited[i, j] = true;
                        FindSequence(i, j, matrix, counter);
                        counter--;
                        visited[i, j] = false;
                    }
                    else
                    {
                        if (counter > maxCount)
                        {
                            maxCount = counter;
                            maxMember = member;
                        }
                    }
                }
            }
        }
    }


    private static bool InMatrix(int row, int col, string[,] matrix)
    {
        if (row  < 0 || row >= matrix.GetLength(0))
        {
            return false;
        }

        if (col < 0 || col >= matrix.GetLength(1))
        {
            return false;
        }

        return true;
    }


    private static string[,] FillStringMatrix(int height, int width)
    {
        string[,] matrix = new string[height, width];
        Console.WriteLine("Please, enter {0} lines with {1} members separate by space:", height, width);

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] line = CheckLine(width);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = line[col];
            }
        }

        return matrix;
    }

    private static string[] CheckLine(int width)
    {
        string[] line = Console.ReadLine().Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        while (line.Length != width)
        {
            Console.Write("Line must have {0} members! Try again: ", width);
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

