namespace MusicArtists.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using Data.Contracts;
    using Data;
    using Newtonsoft.Json.Linq;

    public class Startup
    {
        private static readonly IMusicArtistsDbContext Data = new MusicArtistsDbContext();

        public static void Main()
        {
            Console.WriteLine("Press any key to start...");
            Console.ReadLine();

            var connection = new Uri("http://localhost:27114/");

            PrintXmlCountries(connection, "api/Countries");
            PrintJsonCountries(connection, "api/Countries");
            PostProducers(connection, "api/Producers");
            DeleteCountry(connection, "api/Countries/", 4);

            Console.ReadLine();
        }

        private static async void PrintXmlCountries(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var response = await httpClient.GetAsync(requestPath);
                Console.WriteLine(Environment.NewLine + "Countries: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void PrintJsonCountries(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var response = await httpClient.GetAsync(requestPath);
                Console.WriteLine(Environment.NewLine + "Countries: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void PostProducers(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var json = JObject.Parse("{\"Name\": \"Test Console Producer\"}");

                var response = await httpClient.PostAsync(
                    requestPath,
                    new StringContent(
                        json.ToString(),
                        Encoding.UTF8,
                        "application/json"));

                Console.WriteLine(Environment.NewLine + "Added Producer: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void DeleteCountry(Uri connection, string requestPath, int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;
                var response = await httpClient.DeleteAsync(requestPath + id);

                Console.WriteLine(Environment.NewLine + "Deleted Country:: " + await response.Content.ReadAsStringAsync());
            }
        }
    }
}