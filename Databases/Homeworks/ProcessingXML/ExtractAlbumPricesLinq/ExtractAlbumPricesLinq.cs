namespace ExtractAlbumPricesLinq
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public class ExtractAlbumPricesLinq
    {
        public static void Main(string[] args)
        {
            var doc = XElement.Load("../../../catalog.xml");
            var fiveYearsAgo = DateTime.Now.Year - 5;
            var albums = doc.Elements("album")
                        .Where(x => int.Parse(x.Element("year").Value) >= fiveYearsAgo);
            
            foreach (var node in albums)
            {
                var albumName = node.Element("name").Value;
                var albumArtist = node.Element("artist").Value;
                var albumYear = node.Element("year").Value;
                Console.WriteLine(albumName + " " + albumArtist + " " + albumYear);
            }
        }
    }
}