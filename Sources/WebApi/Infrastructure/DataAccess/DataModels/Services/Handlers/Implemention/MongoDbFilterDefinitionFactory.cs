﻿using System;
using System.Linq.Expressions;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;
using MongoDB.Driver;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services.Handlers.Implemention
{
    public class MongoDbFilterDefinitionFactory<T> : IMongoDbFilterDefinitionFactory<T>
        where T : BaseDataModel
    {
        public FilterDefinition<T> CreateFilterDefinition(Expression<Func<T, bool>> predicate)
        {
            var entityTypeFilter = CreateEntityTypeFilterDefinition();
            var predicateFilter = new ExpressionFilterDefinition<T>(predicate);
            return new FilterDefinitionBuilder<T>().And(entityTypeFilter, predicateFilter);
        }

        private static FilterDefinition<T> CreateEntityTypeFilterDefinition()
        {
            var entityTypeFilter = new ExpressionFilterDefinition<T>(x => x.DataModelTypeName == typeof(T).FullName);
            return entityTypeFilter;
        }
    }
}