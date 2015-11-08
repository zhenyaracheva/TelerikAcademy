namespace TraverseDirectory
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            var directories = Directory.GetDirectories("C:\\WINDOWS");
            TraverseDirectories("C:\\WINDOWS");
        }

        private static void TraverseDirectories(string dir)
        {
            var directories = Directory.GetDirectories(dir);

            if (directories.Length != 0)
            {
                foreach (var path in directories)
                {
                    try
                    {
                        TraverseDirectories(path);
                    }
                    catch
                    {
                    }
                }
            }

            WriteFiles(dir);
        }

        private static void WriteFiles(string dir)
        {
            var files = Directory.GetFiles(dir);
            foreach (var path in files)
            {
                Console.WriteLine(path);
            }
        }
    }
}
