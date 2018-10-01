using System.Net.Http;

namespace TypedClient
{
    public interface IMyHttpClient
    {
        HttpClient Client { get; }
    }
}
