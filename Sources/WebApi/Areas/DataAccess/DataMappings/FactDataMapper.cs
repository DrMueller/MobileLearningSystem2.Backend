using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataMapping;
using MongoDB.Bson.Serialization;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.DataMappings
{
    public class FactDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            BsonClassMap.RegisterClassMap<LearningSession>(
                cm =>
                {
                    cm.AutoMap();
                    cm.MapField("_factIds").SetElementName("_factIds");
                    cm.SetIgnoreExtraElements(true);
                });
        }
    }
}
