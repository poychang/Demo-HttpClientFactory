using System;
using Microsoft.Extensions.DependencyInjection;

namespace TypedClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<App>();
            serviceCollection.AddHttpClient<IMyHttpClient, PoyChangBlogClient>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetRequiredService<App>().Run();
        }
    }
}
