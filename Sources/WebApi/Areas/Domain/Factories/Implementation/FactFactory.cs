using System;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.IdGeneration;

namespace Mmu.Mls2.WebApi.Areas.Domain.Factories.Implementation
{
    public class FactFactory : IFactFactory
    {
        private readonly IEntityIdFactory _entityIdFactory;

        public FactFactory(IEntityIdFactory entityIdFactory)
        {
            _entityIdFactory = entityIdFactory;
        }

        public Fact CreateFact(string questionText, string answerText)
        {
            var entityId = _entityIdFactory.CreateEntityId();
            var result = new Fact(entityId, questionText, answerText, DateTime.Now);

            return result;
        }
    }
}