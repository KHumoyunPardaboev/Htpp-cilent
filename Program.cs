using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace http
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = "https://my-json-server.typicode.com/typicode/demo/comments";
            HttpClient client = new HttpClient();

            try
            {
                var httpReponse = client.GetAsync(url).Result;
                string json = httpReponse.Content.ReadAsStringAsync().Result;
                var jsonDates= JsonConvert.DeserializeObject <Post[]>(json);
                foreach(var item in jsonDates)
                {
                    Console.WriteLine("id: [0], body: [1], postId: [2]", item.id, item.postId, item.body);
                }
            }
            catch (Exception ex)
            {
            
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Dispose();
            }
        }
    }

    public class Post
    {
        public string id { get; set; }
        public string body { get; set; }
        public string postId { get; set; }
    }
}