using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mls2.WebApi.Areas.Application.Dtos;

namespace Mmu.Mls2.WebApi.Areas.Application.Services
{
    public interface IFactService
    {
        Task CreateFactAsync(FactDto dto);

        Task DeleteFactAsync(string id);

        Task<IReadOnlyCollection<FactDto>> LoadAllFactsAsync();

        Task<FactDto> LoadFactbyIdAsync(string id);

        Task UpdateFactAsync(FactDto dto);
    }
}