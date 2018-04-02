using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;

namespace Mmu.Mls2.WebApi.Areas.Domain.Models
{
    public class LearningSession : AggregateRoot
    {
        private List<string> _factIds;

        public LearningSession(string id, string sessionName) : base(id)
        {
            SessionName = sessionName;
            _factIds = new List<string>();
        }

        public IReadOnlyCollection<string> FactIds => _factIds;
        public string SessionName { get; set; }

        public void AlignFacts(IReadOnlyCollection<string> newFactIds)
        {
            if (_factIds == null)
            {
                _factIds = newFactIds.ToList();
                return;
            }

            var factIdsToRemove = _factIds.Where(existingFactId => newFactIds.All(f => f != existingFactId)).ToList();
            _factIds.RemoveAll(f => factIdsToRemove.Contains(f));

            foreach (var newFactId in newFactIds)
            {
                if (_factIds.All(f => f != newFactId))
                {
                    _factIds.Add(newFactId);
                }
            }
        }
    }
}