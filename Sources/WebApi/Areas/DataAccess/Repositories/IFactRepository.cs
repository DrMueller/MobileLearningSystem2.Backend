using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories
{
    public interface IFactRepository : IRepository<Fact>
    {
        Task<IReadOnlyCollection<Fact>> LoadFactsByIds(IReadOnlyCollection<string> factIds);
    }
}