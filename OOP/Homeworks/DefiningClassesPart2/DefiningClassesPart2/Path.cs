namespace Points3DTask
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        public Path()
        {
            this.Points = new List<Point3D>();
        }

        public IList<Point3D> Points { get; set; }

        public void AddPoint(Point3D point)
        {
            this.Points.Add(point);
        }

        public void RemovePoint(Point3D point)
        {
            this.Points.Remove(point);
        }

        public void RemovePoint(int index)
        {
            this.Points.RemoveAt(index);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Path: ");
            foreach (var point in this.Points)
            {
                result.Append(string.Format("{0};", point.ToString()));
            }

            result.Length--;
            return result.ToString().Trim();
        }
    }
}