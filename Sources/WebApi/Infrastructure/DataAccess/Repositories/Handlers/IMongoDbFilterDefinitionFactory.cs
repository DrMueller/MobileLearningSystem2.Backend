﻿using System;
using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;
using MongoDB.Driver;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories.Handlers
{
    public interface IMongoDbFilterDefinitionFactory<T>
        where T : AggregateRoot
    {
        FilterDefinition<T> CreateFilterDefinition(Expression<Func<T, bool>> predicate);
    }
}