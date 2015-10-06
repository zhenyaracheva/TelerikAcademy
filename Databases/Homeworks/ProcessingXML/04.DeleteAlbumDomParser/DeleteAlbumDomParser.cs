namespace DeleteAlbumDomParser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;

    public class DeleteAlbumDomParser
    {
        public static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            var rootNode = doc.DocumentElement;

            DeleteAlbumWithBiggerThanGivenPrice(rootNode, 20.00);
            doc.Save("../../../catalogAfterDelete.xml");
            Console.WriteLine("Saved!");
        }

        private static void DeleteAlbumWithBiggerThanGivenPrice(XmlElement rootNode, double price)
        {
            foreach (XmlElement node in rootNode)
            {
                var currentPrice = double.Parse(node["price"].InnerText);
                if (currentPrice > price)
                {
                    rootNode.RemoveChild(node);
                    DeleteAlbumWithBiggerThanGivenPrice(rootNode, price);
                }
            }
        }
    }
}
