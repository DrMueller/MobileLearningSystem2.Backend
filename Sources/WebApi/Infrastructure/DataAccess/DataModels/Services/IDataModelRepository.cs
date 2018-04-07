using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services
{
    public interface IDataModelRepository<T>
        where T : BaseDataModel
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAsync(Expression<Func<T, bool>> predicate);

        Task<T> LoadSingleAsync(Expression<Func<T, bool>> predicate);

        Task<T> SaveAsync(T dataModelBase);
    }
}