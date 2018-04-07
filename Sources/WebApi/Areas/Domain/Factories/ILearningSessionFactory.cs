using System.Collections.Generic;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Domain.Factories
{
    public interface ILearningSessionFactory
    {
        LearningSession CreateLearningSession(string sessionName);

        LearningSession CreateLearningSession(string id, string sessionName, IReadOnlyCollection<string> factIds);
    }
}