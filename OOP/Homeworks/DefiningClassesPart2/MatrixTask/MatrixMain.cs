namespace MatrixTask
{
    using System;

    public class MatrixMain
    {
        public static void Main()
        {
            Matrix<int> matrix = new Matrix<int>(5, 5);
           
            for (int row = 0; row < matrix.RowsCount; row++)
            {
                for (int col = 0; col < matrix.ColsCount; col++)
                {
                    matrix[row, col] = col;
                }
            }

            Matrix<int> secondMatrix = new Matrix<int>(5, 5);

            for (int row = 0; row < secondMatrix.RowsCount; row++)
            {
                for (int col = 0; col < secondMatrix.ColsCount; col++)
                {
                    secondMatrix[row, col] = row + col;
                }
            }

            Console.WriteLine("First matrix:");
            Console.WriteLine(matrix);
            Console.WriteLine();
            Console.WriteLine("Second matrix:");
            Console.WriteLine(secondMatrix);
            Console.WriteLine();
            Console.WriteLine("First matrix + second matrix");
            Console.WriteLine(matrix + secondMatrix);
            Console.WriteLine();
            Console.WriteLine("First matrix - second matrix");
            Console.WriteLine(secondMatrix - matrix);
            Console.WriteLine();
            Console.WriteLine("First matrix * second matrix");
            Console.WriteLine(matrix * secondMatrix);
            Console.WriteLine();

            Console.WriteLine("True/False");
            if (matrix)
            {
                Console.WriteLine("Matrix contains 0");
            }
            else
            {
                Console.WriteLine("Matrix has no 0");
            }
        }
    }
}
