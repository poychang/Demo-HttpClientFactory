using System;
using System.Threading.Tasks;

namespace TypedClient
{
    public class App
    {
        private readonly IMyHttpClient _httpClient;

        public App(IMyHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Run()
        {
            SendHttpRequest().ConfigureAwait(false);
            Console.ReadLine();
        }

        private async Task SendHttpRequest()
        {
            Console.WriteLine("Connection Start");
            var result = await _httpClient.Client.GetAsync("/");
            Console.WriteLine(result.StatusCode);
            Console.WriteLine("Connection Close");
        }
    }
}
