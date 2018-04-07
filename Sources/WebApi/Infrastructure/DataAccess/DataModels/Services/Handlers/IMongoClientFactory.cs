using MongoDB.Driver;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}