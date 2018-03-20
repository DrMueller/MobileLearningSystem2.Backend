using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mls2.WebApi.Areas.Application.Dtos;

namespace Mmu.Mls2.WebApi.Areas.Application.Services
{
    public interface IFactService
    {
        Task CreateFactAsync(NewFactDto dto);

        Task<IReadOnlyCollection<FactDto>> LoadAllFactsAsync();

        Task<FactDto> LoadFactByIdAsync(string id);

        Task UpdateFactAsync(FactDto dto);

        Task DeleteFactAsync(string id);
    }
}