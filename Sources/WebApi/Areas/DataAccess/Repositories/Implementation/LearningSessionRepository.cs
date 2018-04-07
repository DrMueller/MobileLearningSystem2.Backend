using Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModels.Models;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.Implementation
{
    public class LearningSessionRepository : RepositoryBase<LearningSession, LearningSessionDataModel>
    {
        public LearningSessionRepository(IDataModelRepository<LearningSessionDataModel> dataModelRepository, IDataModelAdapter<LearningSessionDataModel, LearningSession> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
        }
    }
}