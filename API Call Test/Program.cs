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

            //System.Console.WriteLine(clearWord[0]);

            for (int i = 1; i < clearWord.Length; i++)
            {
                clearWord[i] = lines[i].Substring(lines[i].Length - (lines[i].Length - 3));
                //clearWord[i] = lines[i].Remove(1, 2);
                //System.Console.WriteLine(clearWord[i]);
            }

            Random r = new Random();
            int rInt = r.Next(0, 1000);
            int rInt2 = r.Next(0, 7);
            int rInt3 = r.Next(0, 7);

            string[] topText = { "mfw", "jesus christ", "read bottom text", "the cake", "jon is kill", "amogus", "super idol" };
            string[] bottomText = { "mfw api", "it's jason bourne", "read upper text", "is a lie", "no", "amogus", "super idol" };

            //Console.WriteLine(clearWord[rInt]);


            //foreach (var item in myMemes)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //string meme = clearWord[0];
            //Console.WriteLine(meme);
            string imageLink = "https://ronreiter-meme-generator.p.rapidapi.com/meme?meme=" + clearWord[rInt] + 
                "&bottom=" + bottomText[rInt2] + "&top=" + topText[rInt3] +
                "&font=Impact&font_size=50&rapidapi-key=ac024eea7bmsh2c4210b67971157p163a98jsn41384cf35050";
            Console.WriteLine(imageLink);
        }
    }
}
