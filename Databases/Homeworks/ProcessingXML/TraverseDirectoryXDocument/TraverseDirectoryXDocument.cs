namespace TraverseDirectoryXDocument
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    public class TraverseDirectoryXDocument
    {
        public static void Main()
        {
            Console.Write("Please enter path: ");
            var path = Console.ReadLine();

            var doc = new XDocument();
            var docElement = new XElement(Path.GetFileName(path));
            TraverseToXml(path, docElement);
            doc.Add(docElement);
            doc.Save("../../dir.xml");
            Console.WriteLine("Saved!");
        }

        static void TraverseToXml(string dir, XElement doc)
        {
            var directories = Directory.GetDirectories(dir);

            if (directories.Length != 0)
            {
                WriteDirectories(directories, doc);
            }

            WriteFiles(dir, doc);
        }

        private static void WriteDirectories(string[] directories, XElement doc)
        {
            foreach (var path in directories)
            {
                var dirElement = new XElement("dir");
                dirElement.SetAttributeValue("path", path);
                TraverseToXml(path, dirElement);
                doc.Add(dirElement);
            }
        }

        private static void WriteFiles(string dir, XElement doc)
        {
            var files = Directory.GetFiles(dir);
            foreach (var path in files)
            {
                var fileElement = new XElement("file");
                fileElement.SetAttributeValue("name", Path.GetFileNameWithoutExtension(path));
                fileElement.SetAttributeValue("extension", Path.GetExtension(path));
                doc.Add(fileElement);
            }
        }
    }
}
