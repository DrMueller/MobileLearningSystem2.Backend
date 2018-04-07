using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;
using Mmu.Mls2.WebApi.Infrastructure.ServiceProvisioning;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories.Implementation
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IProvisioningService _provisioningService;

        public RepositoryFactory(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public IRepository<T> CreateRepository<T>() where T : AggregateRoot
        {
            var result = _provisioningService.GetService<IRepository<T>>();
            return result;
        }
    }
}