using Microsoft.Extensions.DependencyInjection;

namespace UsingHttpClientFactoryDirectly
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<App>();
            serviceCollection.AddHttpClient();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetRequiredService<App>().Run();
        }
    }
}
