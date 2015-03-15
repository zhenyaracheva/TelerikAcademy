namespace MatrixTask
{
    using System;

    public class Matrix<T>
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


    }
}
