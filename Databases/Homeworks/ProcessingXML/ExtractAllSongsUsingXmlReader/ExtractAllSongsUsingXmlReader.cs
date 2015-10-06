namespace ExtractAllSongsUsingXmlReader
{
    using System;
    using System.Xml;

    public class ExtractAllSongsUsingXmlReader
    {
        public static void Main(string[] args)
        {
            using (XmlReader reader = XmlReader.Create("../../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name=="title")
                    {
                        Console.WriteLine(reader.ReadInnerXml());
                    }
                }
            }
        }
    }
}
