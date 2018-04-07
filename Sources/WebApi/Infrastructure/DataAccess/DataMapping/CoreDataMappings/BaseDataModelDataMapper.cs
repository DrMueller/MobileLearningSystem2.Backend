using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;
using MongoDB.Bson.Serialization;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataMapping.CoreDataMappings
{
    public class BaseDataModelDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            BsonClassMap.RegisterClassMap<BaseDataModel>(
                f =>
                {
                    f.AutoMap();
                    f.MapIdMember(c => c.Id);
                    f.MapMember(c => c.DataModelTypeName);
                });
        }
    }
}