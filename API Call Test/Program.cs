using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace API_Call_Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //        var client = new HttpClient();
            //        var request = new HttpRequestMessage
            //        {
            //            Method = HttpMethod.Get,
            //            RequestUri = new Uri("https://ronreiter-meme-generator.p.rapidapi.com/images"),
            //            Headers =
            //{
            //    { "x-rapidapi-host", "ronreiter-meme-generator.p.rapidapi.com" },
            //    { "x-rapidapi-key", "ac024eea7bmsh2c4210b67971157p163a98jsn41384cf35050" },
            //},
            //        };

            //        string body = "";
            //        using (var response = await client.SendAsync(request))
            //        {
            //            response.EnsureSuccessStatusCode();
            //            body = await response.Content.ReadAsStringAsync();
            //            //Console.WriteLine(body);
            //        }

            var client = new HttpClient();
            var url = "https://ronreiter-meme-generator.p.rapidapi.com/images?rapidapi-key=ac024eea7bmsh2c4210b67971157p163a98jsn41384cf35050"; // Calls the GetProduct() method and passes in the id: 8
            var body = client.GetStringAsync(url).Result;

            //var myMemes = JsonConvert.DeserializeObject<List<Meme>>(body);
            var parsed = JArray.Parse(body).ToString().Replace("[", " ").Replace("]", " ").Replace("\"", "").Replace("\n", "").Trim();
            
            //Console.WriteLine(parsed);
            //string[] memes = parsed.Split(',');

            string[] lines = parsed.Split(',');
            string[] clearWord = new string[lines.Length];
            clearWord[0] = lines[0];

            System.Console.WriteLine(clearWord[0]);

            for (int i = 1; i < clearWord.Length; i++)
            {
                clearWord[i] = lines[i].Remove(1, 2);
                System.Console.WriteLine(clearWord[i]);
            }

            //Console.WriteLine(lines[3]);


            //foreach (var item in myMemes)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //string meme = "You-Were-The-Chosen-One-Star-Wars";
            //string imageLink = "https://ronreiter-meme-generator.p.rapidapi.com/meme?meme=" + meme + "&bottom=Bottom%20Text&top=Top%20Text&font=Impact&font_size=50&&rapidapi-key=ac024eea7bmsh2c4210b67971157p163a98jsn41384cf35050";
            //Console.WriteLine(imageLink);
        }
    }
}
