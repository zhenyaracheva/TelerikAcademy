namespace TraverseDirectory
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class TraverseDirectory
    {
        public static void Main()
        {
            var filePath = "../../dir.xml";
            Console.Write("Please enter path: ");
            var path = Console.ReadLine();

            using (XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement(Path.GetFileName(path));

                TraverseToXml(path, writer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("Saved!");
        }

        static void TraverseToXml(string dir, XmlTextWriter writer)
        {
            var directories = Directory.GetDirectories(dir);

            if (directories.Length != 0)
            {
                WriteDirectories(directories, writer);
            }

            WriteFiles(dir, writer);
        }

        private static void WriteDirectories(string[] directories, XmlTextWriter writer)
        {
            foreach (var path in directories)
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", Path.GetFileName(path));
                writer.WriteAttributeString("path", path);
                TraverseToXml(path, writer);
                writer.WriteEndElement();
            }
        }

        private static void WriteFiles(string dir, XmlTextWriter writer)
        {
            var files = Directory.GetFiles(dir);
            foreach (var path in files)
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileNameWithoutExtension(path));
                writer.WriteAttributeString("extension", Path.GetExtension(path));
                writer.WriteEndElement();
            }
        }
    }
}