using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NamedClients
{
    public class App
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public App(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void Run()
        {
            SendHttpRequest().ConfigureAwait(false);
            Console.ReadLine();
        }

        private async Task SendHttpRequest()
        {
            Console.WriteLine("Connection Start");
            var client = _httpClientFactory.CreateClient(StaticHttpClient.PoyChangBlog);
            var result = await client.GetAsync("/");
            Console.WriteLine(result.StatusCode);
            Console.WriteLine("Connection Close");
        }
    }
}
