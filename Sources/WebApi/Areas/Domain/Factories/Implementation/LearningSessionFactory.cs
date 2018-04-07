using System.Collections.Generic;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.IdGeneration;

namespace Mmu.Mls2.WebApi.Areas.Domain.Factories.Implementation
{
    public class LearningSessionFactory : ILearningSessionFactory
    {
        private readonly IEntityIdFactory _entityIdFactory;

        public LearningSessionFactory(IEntityIdFactory entityIdFactory)
        {
            _entityIdFactory = entityIdFactory;
        }

        public LearningSession CreateLearningSession(string sessionName)
        {
            var entityId = _entityIdFactory.CreateEntityId();
            return new LearningSession(entityId, sessionName);
        }

        public LearningSession CreateLearningSession(string id, string sessionName, IReadOnlyCollection<string> factIds)
        {
            var result = new LearningSession(id, sessionName);
            result.AlignFacts(factIds);

            return result;
        }
    }
}