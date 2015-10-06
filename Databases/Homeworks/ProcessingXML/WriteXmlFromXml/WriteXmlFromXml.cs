namespace WriteXmlFromXml
{
    using System;
    using System.Text;
    using System.Xml;

    public class WriteXmlFromXml
    {
        public static void Main(string[] args)
        {
            var fileName = "../../album.xml";
            var encoding = Encoding.GetEncoding("UTF-8");

            using (var writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                using (var reader = XmlReader.Create("../../../catalog.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "name")
                        {
                            writer.WriteStartElement("album");
                            writer.WriteElementString("name", reader.ReadInnerXml());
                        }
                        else if (reader.Name == "artist")
                        {
                            writer.WriteElementString("artist", reader.ReadInnerXml());
                            writer.WriteEndElement();
                        }
                    }
                }

                writer.WriteEndElement();
            }

            Console.WriteLine("Album.xml is created!");
        }
    }
}