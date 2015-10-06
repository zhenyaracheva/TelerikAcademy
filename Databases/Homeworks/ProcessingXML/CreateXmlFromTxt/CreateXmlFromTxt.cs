namespace CreateXmlFromTxt
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    public class CreateXmlFromTxt
    {
        public static void Main(string[] args)
        {
            var fileName = "../../PeopleInfo.xml";

            using (var writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("people");
                WriteInfoFromTxt("../../PeopleInfo.txt", writer);      
                writer.WriteEndDocument();
            }

            Console.WriteLine("Xml file is done!");
        }

        private static void WriteInfoFromTxt(string path, XmlTextWriter writer)
        {
            using (var reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var personInfo = line.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    WritePerson(writer, personInfo);
                    line = reader.ReadLine();
                }
            }
        }

        private static void WritePerson(XmlTextWriter writer, string[] personInfo)
        {
            writer.WriteStartElement("person");
            writer.WriteElementString("name", personInfo[0].Trim());
            writer.WriteElementString("phone", personInfo[1].Trim());
            writer.WriteElementString("address", personInfo[2].Trim());
            writer.WriteEndElement();
        }
    }
}