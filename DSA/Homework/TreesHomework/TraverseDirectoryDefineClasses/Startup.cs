namespace TraverseDirectoryDefineClasses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        private List<Folder> folders = new List<Folder>();

        public static void Main()
        {
            Console.WriteLine("Loading...");
            string path = "C:\\WINDOWS";
            var root = new Folder("WINDOWS");
            TraverseDirectories(root, path);
            TraverseFolders(root, 0);

        }

        private static void TraverseFolders(Folder root, int depth)
        {
            Console.WriteLine(new string(' ', depth) + root);

            foreach (var child in root.ChildFolders)
            {
                TraverseFolders(child, depth + 4);
            }

            foreach (var file in root.Files)
            {
                Console.WriteLine(new string(' ', depth) + file);
            }
        }

        private static void TraverseDirectories(Folder folder, string dir)
        {
            var directories = Directory.GetDirectories(dir);

            if (directories.Length != 0)
            {
                foreach (var path in directories)
                {
                    try
                    {
                        var name = new DirectoryInfo(path).Name;
                        var childFolder = new Folder(name);
                        folder.ChildFolders.Add(childFolder);
                        TraverseDirectories(childFolder, path);
                    }
                    catch
                    {
                    }
                }
            }

            GetFiles(folder, dir);
        }

        private static void GetFiles(Folder folder, string dir)
        {
            var files = Directory.GetFiles(dir);
            foreach (var path in files)
            {
                var name = new FileInfo(path).Name;
                var size = new FileInfo(path).Length;
                var file = new File(name, size);

                folder.Files.Add(file);
            }
        }
    }
}
