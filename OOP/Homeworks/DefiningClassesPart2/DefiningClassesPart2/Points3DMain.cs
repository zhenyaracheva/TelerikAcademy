namespace Points3DTask
{
    using System;

    public class Points3DMain
    {
        public static void Main(string[] args)
        {
            // test problem 1,2,3:
            Point3D firstPoint = Point3D.O;
            Point3D secondPoint = new Point3D();
            Point3D thirdPoint = new Point3D(2, 12.5, 75);
            Console.WriteLine("First point: {0}", firstPoint);
            Console.WriteLine("Second point: {0}", secondPoint);
            Console.WriteLine("Third point: {0}", thirdPoint);
            double distance = Point3DCalculation.CalculateDistance(secondPoint, thirdPoint);
            Console.WriteLine("Distance between second point and third point is: {0:F2}", distance);

            // test problem 4:
            Path path = new Path();
            path.AddPoint(firstPoint);
            path.AddPoint(secondPoint);
            path.AddPoint(thirdPoint);
            Console.WriteLine(path.ToString());

            string fileName = "savePath";
            PathStorage.Save(path, fileName);
            Path afterLoading = PathStorage.Load(fileName);
            Console.WriteLine("Path after loading:");
            Console.WriteLine(afterLoading.ToString());
        }
    }
}
