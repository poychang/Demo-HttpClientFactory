using Microsoft.Extensions.DependencyInjection;
using System;

namespace NamedClients
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<App>();
            serviceCollection.AddHttpClient(StaticHttpClient.PoyChangBlog, client =>
            {
                client.BaseAddress = new Uri("https://poychang.github.io");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.ConnectionClose = false;
            });

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetRequiredService<App>().Run();
        }
    }

    // 可以用這樣的寫法，建立多個 HttpClient，並且方便取用
    public static class StaticHttpClient
    {
        public static string PoyChangBlog = "PoyChangBlog";
    }
}
