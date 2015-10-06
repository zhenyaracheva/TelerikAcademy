namespace ExtractAlbumPrices
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public class ExtractAlbumPrices
    {

        public static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            int yearBeforeFiveYears = DateTime.Now.Year - 5;
            string path = string.Format(".//album[year>={0}]", yearBeforeFiveYears);

            var albums = doc.SelectNodes(path);

            foreach (XmlElement node in albums)
            {
                var albumName = node["name"].InnerText;
                var albumArtist = node["artist"].InnerText;
                var albumYear = node["year"].InnerText;
                Console.WriteLine(albumName + " " + albumArtist + " " + albumYear);
            }
        }
    }
}
