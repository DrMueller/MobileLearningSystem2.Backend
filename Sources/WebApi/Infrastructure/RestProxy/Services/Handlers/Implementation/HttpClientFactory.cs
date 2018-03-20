using System.Net.Http;

namespace Mmu.Mls2.WebApi.Infrastructure.RestProxy.Services.Handlers.Implementation
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateHttpClient()
        {
            var result = new HttpClient();
            return result;
        }
    }
}