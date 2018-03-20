using MongoDB.Driver;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}