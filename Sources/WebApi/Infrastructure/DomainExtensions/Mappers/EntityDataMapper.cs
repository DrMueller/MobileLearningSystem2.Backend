using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataMapping;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.ModelAbstractions;
using MongoDB.Bson.Serialization;

namespace Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.Mappers
{
    public class EntityDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            BsonClassMap.RegisterClassMap<Entity>(
                f =>
                {
                    f.AutoMap();
                    f.MapIdMember(c => c.Id);
                });
        }
    }
}