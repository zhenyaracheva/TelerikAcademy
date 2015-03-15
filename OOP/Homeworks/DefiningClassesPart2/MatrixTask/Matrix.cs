namespace MatrixTask
{
    using System;
    using System.Text;

    public class Matrix<T> where T : struct, IComparable
    {
        private T[,] matrix;
        private int rowsCount;
        private int colsCount;

        public Matrix(int rows, int cols)
        {
            this.RowsCount = rows;
            this.ColsCount = cols;
            this.matrix = new T[this.RowsCount, this.ColsCount];
        }

        public int RowsCount
        {
            get
            {
                return this.rowsCount;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Rows count must be bigger than 0");
                }

                this.rowsCount = value;
            }
        }

        public int ColsCount
        {
            get
            {
                return this.colsCount;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Cols count must be bigger than 1");
                }

                this.colsCount = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                this.CheckRange(row, col);
                return this.matrix[row, col];
            }

            set
            {
                this.CheckRange(row, col);
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.RowsCount != second.RowsCount || first.ColsCount != second.ColsCount)
            {
                throw new InvalidOperationException("Operation + cannot be performed to matrices with different dimensions");
            }

            Matrix<T> result = new Matrix<T>(first.RowsCount, first.ColsCount);

            for (int i = 0; i < first.RowsCount; i++)
            {
                for (int j = 0; j < first.ColsCount; j++)
                {
                    result[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.RowsCount != second.RowsCount || first.ColsCount != second.ColsCount)
            {
                throw new InvalidOperationException("Operation - cannot be performed  to matrices with different dimensions");
            }

            Matrix<T> result = new Matrix<T>(first.RowsCount, first.ColsCount);

            for (int i = 0; i < first.RowsCount; i++)
            {
                for (int j = 0; j < first.ColsCount; j++)
                {
                    result[i, j] = (dynamic)first[i, j] - second[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.ColsCount != second.RowsCount)
            {
                throw new InvalidOperationException("Matrices cannot be multiplied");
            }

            Matrix<T> result = new Matrix<T>(first.RowsCount, second.ColsCount);

            for (int row = 0; row < result.RowsCount; row++)
            {
                for (int col = 0; col < result.ColsCount; col++)
                {
                    for (int i = 0; i < first.ColsCount; i++)
                    {
                        result[row, col] += (dynamic)first[row, i] * second[i, col];
                    }
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            return CheckForZeroes(matrix);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return CheckForZeroes(matrix);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    result.Append(string.Format("{0,-2} ", this.matrix[row, col]));
                }

                result.Length--;
                result.AppendLine();
            }

            return result.ToString().Trim();
        }

        private static bool CheckForZeroes(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.RowsCount; row++)
            {
                for (int col = 0; col < matrix.ColsCount; col++)
                {
                    if (matrix[row, col] == (dynamic)0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CheckRange(int row, int col)
        {
            if (row < 0 || row >= this.RowsCount)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            if (col < 0 || col >= this.ColsCount)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }
    }
}
