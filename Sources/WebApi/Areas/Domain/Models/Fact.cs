using System;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.Invariance;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.ModelAbstractions;

namespace Mmu.Mls2.WebApi.Areas.Domain.Models
{
    public class Fact : AggregateRoot
    {
        public Fact(
            string questionText,
            string anwerText,
            DateTime creationDate)
        {
            Guard.StringNotNullOrEmpty(() => questionText);
            Guard.StringNotNullOrEmpty(() => anwerText);

            QuestionText = questionText;
            AnswerText = anwerText;
            CreationDate = creationDate;
        }

        public DateTime CreationDate { get; private set; }
        public string QuestionText { get; private set; }
        public string AnswerText { get; private set; }
    }
}