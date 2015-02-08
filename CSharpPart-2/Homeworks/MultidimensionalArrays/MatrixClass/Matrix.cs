namespace MatrixClass
{
    using System;
    using System.Text;

    class Matrix
    {
        private int width;
        private int height;
        private readonly int[,] matrix;
        private int row;
        private int col;

        public int Col
        {
            get
            {
                return this.col;
            }
            set
            {
                if (col < 0 || col >= this.Height)
                {
                    throw new ArgumentOutOfRangeException("Col must be bigger than 0 and smaller than matrix heigth!");
                }

                this.col = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                if (row < 0 || row >= this.Height)
                {
                    throw new ArgumentOutOfRangeException("Row cannot be smaler than 0 or bigger than matrix width!");
                }

                this.row = value;
            }
        }

        private int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Heigth must be bigger than 0!");
                }

                this.height = value;
            }
        }

        private int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Width must be bigger than 0!");
                }

                this.width = value;
            }
        }

        public Matrix(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.matrix = new int[Width, Height];
        }

        public int this[int currentRow, int currentCol]
        {
            get
            {
                return this.matrix[currentRow, currentCol];
            }
            set
            {
                if (currentRow < 0 || currentRow >= this.Width)
                {
                    throw new ArgumentOutOfRangeException("Row was outside the matrix!");
                }

                if (currentCol < 0 || currentCol >= this.Height)
                {
                    throw new ArgumentOutOfRangeException("Col was outside the matrix!");
                }

                matrix[currentRow, currentCol] = value;
            }
        }

        public void SumMatrices(Matrix secondMatrix)
        {
            if (secondMatrix.GetWidth() != this.matrix.GetLength(0))
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal width!");
            }

            if (secondMatrix.GetHeight() != matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal heigth!");

            }

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    matrix[i, j] += secondMatrix[i, j];
                }
            }

        }
                
        public Matrix SumMatrices(Matrix first,Matrix second)
        {
            if (first.GetWidth() != second.GetWidth())
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal width!");
            }

            if (first.GetHeight() != second.GetHeight())
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal heigth!");

            }

            Matrix result = new Matrix(first.Width, first.Height);

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                   result[i,j]= first[i, j] + second[i, j];
                }
            }

            return result;
        }

        public void SubtractMatrices(Matrix second)
        {
            if (second.GetWidth() != this.matrix.GetLength(0))
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal width!");
            }

            if (second.GetHeight() != matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal heigth!");

            }

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    matrix[i, j] -= second[i, j];
                }
            }
        }

        public Matrix SubtractMatrices(Matrix first, Matrix second)
        {
            if (first.GetWidth() != second.GetWidth())
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal width!");
            }

            if (first.GetHeight() != second.GetHeight())
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal heigth!");

            }

            Matrix result = new Matrix(first.Width, first.Height);

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    result[i, j] = first[i, j] - second[i, j];
                }
            }

            return result;
        }

        public int GetWidth()
        {
            return this.Width;
        }

        public int GetHeight()
        {
            return this.Height;
        }

        public void MultiplyMatrices(Matrix second)
        {
            if (second.GetWidth() != this.matrix.GetLength(0))
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal width!");
            }

            if (second.GetHeight() != matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal heigth!");

            }

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= second[i, j];
                }
            }
        }

        public Matrix MultiplyMatrices(Matrix first, Matrix second)
        {
            if (first.GetWidth() != second.GetWidth())
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal width!");
            }

            if (first.GetHeight() != second.GetHeight())
            {
                throw new ArgumentOutOfRangeException("Matrices don't have equal heigth!");

            }

            Matrix result = new Matrix(first.Width, first.Height);

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    result[i, j] = first[i, j] * second[i, j];
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < Width; row++)
            {
                for (int col = 0; col < Height; col++)
                {
                    result.AppendFormat("{0,3} ", this.matrix[row, col]);
                }

               result.Append("\n");
            }
            result.Length--;
            return  result.ToString();
        }
    }
}
