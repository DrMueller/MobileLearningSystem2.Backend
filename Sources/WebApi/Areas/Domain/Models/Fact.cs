﻿using System;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mls2.WebApi.Areas.Domain.Models
{
    public class Fact : AggregateRoot
    {
        public Fact(
            string id,
            string questionText,
            string anwerText,
            DateTime creationDate) : base(id)
        {
            Guard.StringNotNullOrEmpty(() => questionText);

            QuestionText = questionText;
            AnswerText = anwerText;
            CreationDate = creationDate;
        }

        public string AnswerText { get; set; }
        public DateTime CreationDate { get; }
        public string QuestionText { get; set; }
    }
}