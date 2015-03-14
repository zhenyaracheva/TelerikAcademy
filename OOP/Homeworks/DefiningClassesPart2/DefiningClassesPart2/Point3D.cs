namespace Points3DTask
{
    using System.Text;

    public struct Point3D
    {
        private static readonly Point3D StartPoint;

        static Point3D()
        {
            Point3D.StartPoint = new Point3D();
        }

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D O
        {
            get
            {
                return StartPoint;
            }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(string.Format("[x = {0}, y = {1}, z = {2}]", this.X, this.Y, this.Z));

            return result.ToString();
        }
    }
}
