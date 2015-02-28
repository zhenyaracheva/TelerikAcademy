//Problem 5. Maximal area sum

//Write a program that reads a text file containing a square matrix of numbers.
//Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
//The first line in the input file contains the size of matrix N.
//Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file.
//Example:

//input	        output
//4               17
//2 3 3 4 
//0 2 3 4 
//3 7 1 2 
//4 3 3 2	        


using System;
using System.Linq;
using System.IO;

class SolveMaximalAreaSum
{
    static void Main()
    {

        int[,] matrix;

        using (StreamReader reader = new StreamReader(@"..\..\Matrix.txt"))
        {
            int line = int.Parse(reader.ReadLine());
            matrix = new int[line, (line)];

            for (int row = 0; row < line; row++)
            {
                int[] currentLine = reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < currentLine.Length; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }
        }

        int maxSum = 0;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        using (StreamWriter writer = new StreamWriter(@"..\..\Result.txt"))
        {
            writer.WriteLine(maxSum);
        }

        Console.WriteLine("Done!");
    }
}

