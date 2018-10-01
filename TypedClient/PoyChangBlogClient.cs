using System;
using System.Net.Http;

namespace TypedClient
{
    public class PoyChangBlogClient : IMyHttpClient
    {
        public HttpClient Client { get; }

        public PoyChangBlogClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://poychang.github.io");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.ConnectionClose = false;
            Client = httpClient;
        }
    }
}
