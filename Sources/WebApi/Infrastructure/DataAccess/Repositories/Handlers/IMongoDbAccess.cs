using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot;
    }
}