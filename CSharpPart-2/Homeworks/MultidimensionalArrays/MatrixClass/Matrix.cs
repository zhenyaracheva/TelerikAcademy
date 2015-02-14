namespace MatrixClass
{
    using System;
    using System.Text;

    class Matrix
    {
        private double[,] innerMatrix;

        public Matrix(double[,] matrix)
        {
            this.innerMatrix = matrix;
        }

        public double this[int currentRow, int currentCol]
        {
            get
            {
                return this.innerMatrix[currentRow, currentCol];
            }
            set
            {
                if (currentRow < 0 || currentRow >= innerMatrix.GetLength(0))
                {
                    throw new ArgumentOutOfRangeException("Row was outside the matrix!");
                }

                if (currentCol < 0 || currentCol >= this.innerMatrix.GetLength(1))
                {
                    throw new ArgumentOutOfRangeException("Col was outside the matrix!");
                }

                innerMatrix[currentRow, currentCol] = value;
            }
        }

        public int GetHeight()
        {
            return this.innerMatrix.GetLength(0);
        }

        public int GetWidth()
        {
            return this.innerMatrix.GetLength(1);
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            if (first.GetHeight() != second.GetHeight() || first.GetWidth() != second.GetWidth())
            {
                Console.WriteLine("Cannot add matrixes!");
                Environment.Exit(0);
            }

            Matrix result = new Matrix(new double[first.GetHeight(), first.GetWidth()]);
            for (int i = 0; i < first.GetHeight(); i++)
            {
                for (int j = 0; j < first.GetWidth(); j++)
                {
                    result[i, j] = first[i, j] + second[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix first, Matrix second)
        {
            if (first.GetHeight() != second.GetHeight() || first.GetWidth() != second.GetWidth())
            {
                Console.WriteLine("Cannot add matrixes!");
                Environment.Exit(0);
            }
            Matrix result = new Matrix(new double[first.GetHeight(), first.GetWidth()]);

            for (int i = 0; i < first.GetHeight(); i++)
            {
                for (int j = 0; j < first.GetWidth(); j++)
                {
                    result[i, j] = first[i, j] - second[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (first.GetWidth() != second.GetHeight())
            {
                Console.WriteLine("Matrices cannot be multiplied!");
                Environment.Exit(0);
            }

            Matrix result = new Matrix(new double[first.GetHeight(), second.GetWidth()]);

            for (int row = 0; row < result.GetHeight(); row++)
            {
                for (int col = 0; col < result.GetWidth(); col++)
                {

                    for (int i = 0; i < first.GetWidth(); i++)
                    {

                        result[row, col] += first[row, i] * second[i, col];
                    }
                }
            }

            return result;
        }




        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.innerMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.innerMatrix.GetLength(1); col++)
                {
                    result.AppendFormat("{0,3} ", this.innerMatrix[row, col]);
                }

                result.Append("\n");
            }
            result.Length--;
            return result.ToString();
        }
    }
}
