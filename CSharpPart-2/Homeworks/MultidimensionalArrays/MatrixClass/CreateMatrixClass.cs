//Problem 6.* Matrix class

//Write a class Matrix, to hold a matrix of integers. Overload the operators for adding, subtracting and 
//multiplying of matrices, indexer for accessing the matrix content and ToString().

namespace MatrixClass
{
    using System;

    class CreateMatrixClass
    {
        static void Main()
        {
            Matrix matrix = new Matrix(5, 6);

            for (int row = 0; row < matrix.GetWidth(); row++)
            {
                for (int col = 0; col < matrix.GetHeight(); col++)
                {
                    matrix[row, col] = col * col + row;
                }
            }

            Console.WriteLine(matrix.ToString());
        }
    }

}