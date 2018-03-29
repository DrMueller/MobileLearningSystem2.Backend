using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<IReadOnlyCollection<T>> LoadAsync(Expression<Func<T, bool>> predicate);

        Task<T> LoadByIdAsync(string id);

        Task<T> LoadSingleAsync(Expression<Func<T, bool>> predicate);

        Task<T> SaveAsync(T aggregateRoot);
    }
}