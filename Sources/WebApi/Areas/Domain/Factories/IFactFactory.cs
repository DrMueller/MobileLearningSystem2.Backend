using System;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Domain.Factories
{
    public interface IFactFactory
    {
        Fact CreateFact(string questionText, string answerText);
    }
}