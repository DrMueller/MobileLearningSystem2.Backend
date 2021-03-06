﻿using System;
using Mmu.Mlh.DomainExtensions.Areas.Factories;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Domain.Factories.Implementation
{
    public class FactFactory : IFactFactory
    {
        private readonly IEntityIdFactory _entityIdFactory;

        public FactFactory(IEntityIdFactory entityIdFactory)
        {
            _entityIdFactory = entityIdFactory;
        }

        public Fact CreateFact(string questionText, string answerText)
        {
            var entityId = _entityIdFactory.CreateEntityId();
            return CreateFact(entityId, questionText, answerText);
        }

        public Fact CreateFact(string id, string questionText, string answerText)
        {
            var result = new Fact(id, questionText, answerText, DateTime.Now);
            return result;
        }
    }
}