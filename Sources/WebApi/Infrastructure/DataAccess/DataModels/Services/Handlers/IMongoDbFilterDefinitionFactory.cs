using System;
using System.Linq.Expressions;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;
using MongoDB.Driver;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services.Handlers
{
    public interface IMongoDbFilterDefinitionFactory<T>
        where T : BaseDataModel
    {
        FilterDefinition<T> CreateFilterDefinition(Expression<Func<T, bool>> predicate);
    }
}