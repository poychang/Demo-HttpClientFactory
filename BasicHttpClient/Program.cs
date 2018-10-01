using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasicHttpClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SendHttpRequest().ConfigureAwait(false);
            SendMultipleHttpRequest(5).ConfigureAwait(false);

            Console.ReadLine();
        }

        private static async Task SendHttpRequest()
        {
            Console.WriteLine("Connection Start");
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("https://poychang.github.io");
                Console.WriteLine(result.StatusCode);
            }
            Console.WriteLine("Connection Close");
        }

        private static async Task SendMultipleHttpRequest(int time)
        {
            Console.WriteLine("Connection Start");
            for (var i = 0; i < time; i++)
            {
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync("https://poychang.github.io");
                    Console.WriteLine(result.StatusCode);
                }
            }
            Console.WriteLine("Connection Close");
        }
    }
}
