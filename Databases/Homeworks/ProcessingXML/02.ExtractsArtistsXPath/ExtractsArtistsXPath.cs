namespace ExtractsArtistsXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using ExtractsArtists;

    public class ExtractsArtistsXPath
    {
        public static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            string path = ".//album";

            XmlNodeList artist = doc.SelectNodes(path);
            var album = GetAllAlbumArtistAppearence(artist);
            ExtractsArtistsDOMParser.Print(album);
        }

        public static IDictionary<string, int> GetAllAlbumArtistAppearence(XmlNodeList rootNode)
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