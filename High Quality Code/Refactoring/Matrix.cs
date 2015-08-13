namespace MatrixTask
{
    using System;
    using System.Text;

    public class Matrix
    {
        private const int DirectionsCount = 8;
        private const int MatrixMinSize = 1;
        private const int MatrixMaxSize = 100;

        private int[,] matrix;
        private int row;
        private int col;
        private int directionRow;
        private int directionCol;
        private int stepIndex;
        private int size;

        public Matrix(int size)
        {
            this.Size = size;
            this.row = 0;
            this.col = 0;
            this.directionRow = 1;
            this.directionCol = 1;
            this.stepIndex = 1;
            this.matrix = FIllMatrixClockwise();
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value < Matrix.MatrixMinSize || value > Matrix.MatrixMaxSize)
                {
                    throw new ArgumentOutOfRangeException("Matrix size must be between " + Matrix.MatrixMinSize + " and " + Matrix.MatrixMaxSize);
                }

                this.size = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            for (int rowIndex = 0; rowIndex < this.matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < this.matrix.GetLength(1); colIndex++)
                {
                    output.AppendFormat("{0,3}", this.matrix[rowIndex, colIndex]);
                }

                output.AppendLine();
            }

            return output.ToString();
        }

        private void ChangeDirection()
        {
            /// directions:  row col
            /// up:          -1;  0
            /// up-rigth:    -1;  1
            /// rigth:        0;  1
            /// down-rigth:   1;  1
            /// down:         1;  0
            /// down-left:    1; -1
            /// left:         0; -1
            /// up-left:     -1; -1

            int[] dirRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currentDirection = 0;

            for (int count = 0; count < Matrix.DirectionsCount; count++)
            {
                if (dirRow[count] == this.directionRow && dirCol[count] == this.directionCol)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == Matrix.DirectionsCount - 1)
            {
                this.directionRow = dirRow[0];
                this.directionCol = dirCol[0];
            }
            else
            {
                this.directionRow = dirRow[currentDirection + 1];
                this.directionCol = dirCol[currentDirection + 1];
            }
        }

        private bool CheckFullMatrix()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (this.matrix[row, col] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int[,] FIllMatrixClockwise()
        {
            this.matrix = new int[this.Size, this.Size];

            while (true)
            {
                this.matrix[this.row, this.col] = this.stepIndex;

                if (this.CheckFullMatrix())
                {
                    break;
                }

                var nextRow = this.row + this.directionRow;
                var nextCol = this.col + this.directionCol;

                if (this.InRange(nextRow, nextCol))
                {
                    this.row += this.directionRow;
                    this.col += this.directionCol;
                    this.stepIndex++;
                }
                else if (!this.CanMoveNear())
                {
                    this.FindEmptyCell();
                    this.directionRow = 1;
                    this.directionCol = 1;
                    this.stepIndex++;
                }
                else
                {
                    this.ChangeDirection();
                }
            }

            return this.matrix;
        }

        private bool CanMoveNear()
        {
            for (int i = this.row - 1; i <= this.row + 1; i++)
            {
                for (int j = this.col - 1; j <= this.col + 1; j++)
                {
                    if (this.InRange(i, j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void FindEmptyCell()
        {
            for (int rowIndex = 0; rowIndex < this.Size; rowIndex++)
            {
                for (int colIndex = 0; colIndex < this.Size; colIndex++)
                {
                    if (this.matrix[rowIndex, colIndex] == 0)
                    {
                        this.row = rowIndex;
                        this.col = colIndex;
                        return;
                    }
                }
            }
        }

        private bool InRange(int currentRow, int currentCol)
        {
            if (currentRow < 0 || currentRow >= this.Size)
            {
                return false;
            }

            if (currentCol < 0 || currentCol >= this.Size)
            {
                return false;
            }

            if (this.matrix[currentRow, currentCol] != 0)
            {
                return false;
            }

            return true;
        }
    }
}