using System;
using System.Linq.Expressions;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.ModelAbstractions;

namespace Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.Specifications
{
    public interface ISpecification<T>
        where T : AggregateRoot
    {
        bool IsSatisfiedBy(T aggregateRoot);

        Expression<Func<T, bool>> ToExpression();
    }
}