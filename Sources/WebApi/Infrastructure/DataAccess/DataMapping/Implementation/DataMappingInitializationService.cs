using System.Collections.Generic;
using System.Linq;
using Mmu.Mls2.WebApi.Infrastructure.ServiceProvisioning;
using MongoDB.Bson.Serialization;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataMapping.Implementation
{
    public class DataMappingInitializationService : IDataMappingInitializationService
    {
        private readonly IReadOnlyCollection<IDataMapper> _dataMappers;
        private readonly object _lock = new object();

        public DataMappingInitializationService(IProvisioningService provisioningService)
        {
            _dataMappers = provisioningService.GetAllServices<IDataMapper>();
        }

        public void AssureMappingsAreInitialized()
        {
            if (BsonClassMap.GetRegisteredClassMaps().Any())
            {
                return;
            }

            lock (_lock)
            {
                if (BsonClassMap.GetRegisteredClassMaps().Any())
                {
                    return;
                }

                foreach (var dataMapper in _dataMappers)
                {
                    dataMapper.InitializeDataMapping();
                }
            }
        }
    }
}