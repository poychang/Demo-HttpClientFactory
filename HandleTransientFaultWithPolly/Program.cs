using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Net.Http;
using Polly.Extensions.Http;

namespace HandleTransientFaultWithPolly
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<App>();

            var retryPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10));
            var retry3TimesPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .RetryAsync(3);

            var noOp = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();

            serviceCollection.AddHttpClient(StaticHttpClient.PoyChangBlog)
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddPolicyHandler(request => request.Method == HttpMethod.Get ? retryPolicy : noOp);

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
