namespace Points3DTask
{
    using System;
    using System.IO;
    using System.Linq;

    public static class PathStorage
    {
        public static void Save(Path path, string pathName)
        {
            var writer = new StreamWriter(@"..\..\" + string.Format("{0}.txt", pathName));

            using (writer)
            {
                writer.WriteLine(path.ToString());
            }
        }

        public static Path Load(string pathName)
        {
            var reader = new StreamReader(@"..\..\" + string.Format("{0}.txt", pathName));
            Path currerntPath = new Path();

            using (reader)
            {
                string line = reader.ReadLine();
                string[] currentData = line.Split(new[] { '[', ']', ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < currentData.Length; i++)
                {
                    double[] data = currentData[i].Split(new char[] { '=', ' ', ',', 'x', 'y', 'z' }, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(double.Parse)
                                                  .ToArray();
                    Point3D point = new Point3D(data[0], data[1], data[2]);
                    currerntPath.Points.Add(point);
                }
            }

            return currerntPath;
        }
    }
}
