using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;
using MongoDB.Driver;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : BaseDataModel;
    }
}