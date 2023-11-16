using Microsoft.Net.Http.Headers;
using System.Text;

namespace CurrentAccountAPI.Infra.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddDefaultHeaders(this HttpClient client)
        {
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "*/*");
            client.DefaultRequestHeaders.Add(HeaderNames.AcceptEncoding, "gzip, deflate, br");
            client.DefaultRequestHeaders.Add(HeaderNames.Connection, "keep-alive");
        }

        public static void AddBasicAuthorization(this HttpClient client, string user, string password)
            => client.DefaultRequestHeaders.Add(HeaderNames.Authorization,
                $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"))}");

        public static void AddBearerAuthorization(this HttpClient client, string authorization)
            => client.DefaultRequestHeaders.Add(HeaderNames.Authorization,
                $"Bearer {authorization}");
    }
}