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
            double[,] firstInt = 
            {
              {1, 2, 1},
              {3, 4, 2},
              {1, 2, 3}
              
            };

            double[,] secondInt = 
            {
                {1, 2, 3},
                {4, 5, 3},
                {1, 2, 3}
            };

            Matrix first = new Matrix(firstInt);
            Matrix second = new Matrix(secondInt);

            Console.WriteLine(first + second);
            Console.WriteLine();
            Console.WriteLine(first - second);
            Console.WriteLine();
            Console.WriteLine(first * second);
        }

    }

}