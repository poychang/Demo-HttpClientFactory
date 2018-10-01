using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UsingHttpClientFactoryDirectly
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
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://poychang.github.io");
            Console.WriteLine(result.StatusCode);
            Console.WriteLine("Connection Close");
        }
    }
}
