using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Domain.Factories
{
    public interface ILearningSessionFactory
    {
        LearningSession CreateLearningSession(string sessionName);
    }
}