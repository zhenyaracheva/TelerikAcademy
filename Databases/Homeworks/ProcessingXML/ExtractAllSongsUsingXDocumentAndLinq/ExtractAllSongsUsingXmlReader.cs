namespace ExtractAllSongsUsingXDocumentAndLinq
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public class ExtractAllSongsUsingXmlReader
    {
        public static void Main(string[] args)
        {
            var doc = XDocument.Load("../../../catalog.xml");
            var songs = doc.Element("catalog")
                .Elements("album")
                .Elements("songs") 
                .Elements("song")
                .Elements("title");

            foreach (var song in songs)
            {
                Console.WriteLine(song.Value);
            }
        }
    }
}