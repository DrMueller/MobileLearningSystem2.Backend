using System.Threading.Tasks;
using Mmu.Mls2.WebApi.Infrastructure.RestProxy.Models;

namespace Mmu.Mls2.WebApi.Infrastructure.RestProxy.Services
{
    public interface IRestProxy
    {
        Task<T> PerformApiCallAsync<T>(RestApiCall restApiCall);
    }
}