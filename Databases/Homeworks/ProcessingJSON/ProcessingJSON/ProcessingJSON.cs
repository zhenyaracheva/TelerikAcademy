namespace ProcessingJSON
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class ProcessingJSON
    {
        private const string DataPath = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var content = GetDataContent();
            var doc = new XmlDocument();
            doc.LoadXml(content);

            var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            var jsonObj = JObject.Parse(json);
            var titles = GetTitles(jsonObj);
            var videos = GetVideos(jsonObj);
            var html = CreateHtml(videos);
            SaveHml(html);
            Console.WriteLine("Saved!");
        }

        private static string GetDataContent()
        {
            var webClient = new WebClient();
            var data = webClient.DownloadData(ProcessingJSON.DataPath);
            return Encoding.UTF8.GetString(data);
        }

        private static void SaveHml(string html)
        {
            using (var writer = new StreamWriter("../../index.html", false, Encoding.UTF8))
            {
                writer.Write(html);
            }
        }

        private static string CreateHtml(IEnumerable<Video> videos)
        {
            var template = "<html><body><div><h1>Videos:</h1>{0}</div></body></html>";

            var html = new StringBuilder();

            foreach (var video in videos)
            {
                html.Append("<div>");
                html.Append("<h2>" + video.Title + "</h2>");
                html.Append("<iframe src=\"http://www.youtube.com/embed/" + video.Id + "?autoplay=0 frameborder=\"0\" border=\"0\" ");
                html.Append("cellspacing=\"0\" style=\"border-style: none;width: 50%; height: 320px;\"></iframe>");              
                html.Append("</div>");
                html.Append("<a href=\"" + video.Link + "\">Link to Youtube</a>");
            }

            return string.Format(template, html.ToString());
        }

        private static IEnumerable<Video> GetVideos(JObject jsonObj)
        {
            return jsonObj["feed"]["entry"]
                     .Select(v => JsonConvert.DeserializeObject<Video>(v.ToString()));
        }

        private static IEnumerable<JToken> GetTitles(JObject jsonObj)
        {
            return jsonObj["feed"]["entry"].Select(e => e["title"]);
        }
    }
}