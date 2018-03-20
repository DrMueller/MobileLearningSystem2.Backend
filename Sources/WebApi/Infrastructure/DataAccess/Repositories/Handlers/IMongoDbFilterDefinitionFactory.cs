using System;
using System.Linq.Expressions;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories.Handlers
{
    public interface IMongoDbFilterDefinitionFactory<T>
        where T : AggregateRoot
    {
        FilterDefinition<T> CreateFilterDefinition(Expression<Func<T, bool>> predicate);
    }
}