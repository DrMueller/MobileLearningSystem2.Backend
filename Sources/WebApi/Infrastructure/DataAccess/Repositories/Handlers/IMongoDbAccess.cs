using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;
using MongoDB.Driver;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot;
    }
}