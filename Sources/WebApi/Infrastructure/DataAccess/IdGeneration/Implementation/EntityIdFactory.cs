using MongoDB.Bson;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.IdGeneration.Implementation
{
    public class EntityIdFactory : IEntityIdFactory
    {
        public string CreateEntityId() => ObjectId.GenerateNewId().ToString();
    }
}