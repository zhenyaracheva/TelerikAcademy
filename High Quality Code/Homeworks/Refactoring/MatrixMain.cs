namespace MatrixTask
{
    using System;
    using System.Text;

    public class MatrixMain
    {
        public static void Main(string[] args)
        {
            var size = 6;
            Matrix matrix = new Matrix(size);
            Console.WriteLine(matrix);
        }
    }
}
