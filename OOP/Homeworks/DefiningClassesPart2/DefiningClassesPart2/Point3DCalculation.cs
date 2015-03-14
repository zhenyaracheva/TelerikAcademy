namespace Points3DTask
{
    using System;

    public static class Point3DCalculation
    {
        public static double CalculateDistance(Point3D first, Point3D second)
        {
            double distanceX = (second.X - first.X) * (second.X - first.X);
            double distanceY = (second.Y - first.Y) * (second.Y - first.Y);
            double distanceZ = (second.Z - first.Z) * (second.Z - first.Z);

            return Math.Sqrt(distanceX + distanceY + distanceZ);
        }
    }
}
