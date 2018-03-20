using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>()
            where T : AggregateRoot;
    }
}