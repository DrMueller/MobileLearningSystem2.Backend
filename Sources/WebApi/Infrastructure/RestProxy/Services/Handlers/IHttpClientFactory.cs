using System.Net.Http;

namespace Mmu.Mls2.WebApi.Infrastructure.RestProxy.Services.Handlers
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}