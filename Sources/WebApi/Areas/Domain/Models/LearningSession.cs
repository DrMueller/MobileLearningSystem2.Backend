using System.Collections.Generic;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.ModelAbstractions;

namespace Mmu.Mls2.WebApi.Areas.Domain.Models
{
    public class LearningSession : AggregateRoot
    {
        private List<long> _factIds;

        public LearningSession()
        {
            _factIds = new List<long>();
        }

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