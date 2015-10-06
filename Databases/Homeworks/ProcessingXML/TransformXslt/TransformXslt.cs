namespace TransformXslt
{
    using System;
    using System.Xml.Xsl;
    public class TransformXslt
    {
        public static void Main(string[] args)
        {
            var doc = new XslCompiledTransform();
            doc.Load("../../../catalog.xsl");
            doc.Transform("../../../catalog.xml", "../../../catalog.html");
            Console.WriteLine("Saved!");
        }
    }
}
