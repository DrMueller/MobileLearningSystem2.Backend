using System;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Domain.Factories.Implementation
{
    public class FactFactory : IFactFactory
    {
        public Fact CreateFact(string questionText, string answerText) => new Fact(questionText, answerText, DateTime.Now);
    }
}