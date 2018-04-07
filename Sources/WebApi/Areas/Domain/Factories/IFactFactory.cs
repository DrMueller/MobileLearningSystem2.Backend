using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Domain.Factories
{
    public interface IFactFactory
    {
        Fact CreateFact(string questionText, string answerText);

        Fact CreateFact(string id, string questionText, string answerText);
    }
}