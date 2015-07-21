namespace CohesionAndCoupling
{
    using System;

    public static class GeometryUnits
    {
        public static double CalcVolume(double width, double heigth, double depth)
        {
            double volume = width * heigth * depth;
            return volume;
        }

        public static double CalcDiagonalXYZ(double width, double heigth, double depth)
        {
            double distance = DistanceCalculator.Distance3D(0, 0, 0, width, heigth, depth);
            return distance;
        }

        public static double CalcDiagonalXY(double width, double heigth)
        {
            double distance = DistanceCalculator.Distance2D(0, 0, width, heigth);
            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            double distance = DistanceCalculator.Distance2D(0, 0, width, depth);
            return distance;
        }

        public static double CalcDiagonalYZ(double heigth, double depth)
        {
            double distance = DistanceCalculator.Distance2D(0, 0, heigth, depth);
            return distance;
        }
    }
}
