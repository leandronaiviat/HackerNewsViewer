using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNewsWPFMVVM
{
    public static class HackerNewsApi
    {
        static HttpClient Client = new HttpClient();
        
        public static async Task<T> ApiHandler<T>(string url)
        {
            using (HttpResponseMessage response = await Client.GetAsync(url+".json"))
            {
                string json = await response.Content.ReadAsStringAsync();
                T ApiResponse = JsonConvert.DeserializeObject<T>(json);
                return ApiResponse;
            }
        }
    }
}
