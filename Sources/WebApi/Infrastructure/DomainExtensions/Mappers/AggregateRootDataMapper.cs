using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataMapping;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.ModelAbstractions;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.Mappers
{
    public class AggregateRootDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            BsonClassMap.RegisterClassMap<AggregateRoot>(
                f =>
                {
                    f.AutoMap();
                    f.MapIdMember(c => c.Id).SetIdGenerator(new StringObjectIdGenerator());
                    f.MapMember(c => c.AggregateTypeName);
                });
        }
    }
}