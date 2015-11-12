namespace ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    using Newtonsoft.Json;

    public class Startup
    {
        public static void Main()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");

            Console.Write("Enter query or press enter to use default: ");
            var query = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(query))
            {
                query = "a";
            }

            Console.Write("Enter number: ");
            var number = int.Parse(Console.ReadLine());
            if (number < 1)
            {
                number = 5;
            }

            PrintPosts(client, query, number);
        }

        public static void PrintPosts(HttpClient httpClient, string query, int itemsCount)
        {
            var response = httpClient.GetAsync("posts").Result;
            var res = response.Content.ReadAsStringAsync().Result;

            var jsons = JsonConvert.DeserializeObject<List<Post>>(res);
            var filtered = jsons.Where(x => x.Title.Contains(query))
                                .Take(itemsCount);

            Console.WriteLine(string.Join(Environment.NewLine, filtered));
        }
    }
}
