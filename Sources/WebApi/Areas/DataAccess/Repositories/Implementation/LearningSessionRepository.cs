using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModeling.Models;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.Implementation
{
    public class LearningSessionRepository : RepositoryBase<LearningSession, LearningSessionDataModel>
    {
        public LearningSessionRepository(IDataModelRepository<LearningSessionDataModel> dataModelRepository, IDataModelAdapter<LearningSessionDataModel, LearningSession> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
        }
    }
}