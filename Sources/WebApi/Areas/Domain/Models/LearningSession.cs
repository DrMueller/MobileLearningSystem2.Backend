using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;

namespace Mmu.Mls2.WebApi.Areas.Domain.Models
{
    public class LearningSession : AggregateRoot
    {
        private List<long> _factIds;

        public LearningSession(string id) : base(id) => _factIds = new List<long>();

        public IReadOnlyCollection<long> FactIds => _factIds;

        public void AddFactIdIfNotExisting(long factId)
        {
            if (_factIds.Contains(factId))
            {
                _factIds.Add(factId);
            }
        }
    }
}