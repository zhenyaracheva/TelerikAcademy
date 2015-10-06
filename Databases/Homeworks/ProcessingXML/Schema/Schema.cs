namespace Schema
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class Schema
    {
        public static void Main(string[] args)
        {
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, "../../catalog.xsd");

            var validDoc = XDocument.Load("../../catalog.xml");  
            CheckSchema(validDoc, schema, "catalog.xml");

            var invalidDoc = XDocument.Load("../../invalidCatalog.xml");
            CheckSchema(invalidDoc, schema, "invalidCatalog.xml");
        }

        private static void CheckSchema(XDocument document, XmlSchemaSet schema, string file)
        {
            document.Validate(schema, (obj, ev) =>
            {
                Console.WriteLine("* {0} * {1}", file, ev.Message);
            });
        }
    }
}
