using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.IdGeneration;

namespace Mmu.Mls2.WebApi.Areas.Domain.Factories.Implementation
{
    public class LearningSessionFactory : ILearningSessionFactory
    {
        private readonly IEntityIdFactory _entityIdFactory;

        public LearningSessionFactory(IEntityIdFactory entityIdFactory) => _entityIdFactory = entityIdFactory;

        public LearningSession CreateLearningSession(string sessionName)
        {
            var entityId = _entityIdFactory.CreateEntityId();
            var result = new LearningSession(entityId, sessionName);

            return result;
        }
    }
}