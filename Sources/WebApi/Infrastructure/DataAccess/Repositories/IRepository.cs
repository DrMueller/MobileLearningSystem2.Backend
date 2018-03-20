using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.ModelAbstractions;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.Specifications;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<IReadOnlyCollection<T>> LoadAsync(ISpecification<T> spec);

        Task<T> LoadSingleAsync(ISpecification<T> spec);

        Task<T> LoadByIdAsync(string id);

        Task<T> SaveAsync(T aggregateRoot);
    }
}