namespace ExtractsArtists
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractsArtistsDOMParser
    {
        public static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            var rootNode = doc.DocumentElement;
            var album = GetAllAlbumArtistAppearence(rootNode);
            Print(album);
        }

        public static void Print(IDictionary<string, int> album)
        {
            foreach (var artist in album)
            {
                Console.WriteLine("Artist: {0}; Albums: {1}", artist.Key, artist.Value);
            }
        }

        public static IDictionary<string, int> GetAllAlbumArtistAppearence(XmlElement rootNode)
        {
            var artists = new Dictionary<string, int>();

            foreach (XmlElement node in rootNode)
            {
                var artist = node["artist"].InnerText;
                if (artists.ContainsKey(artist))
                {
                    artists[artist]++;
                }
                else
                {
                    artists.Add(artist, 1);
                }
            }

            return artists;
        }
    }
}