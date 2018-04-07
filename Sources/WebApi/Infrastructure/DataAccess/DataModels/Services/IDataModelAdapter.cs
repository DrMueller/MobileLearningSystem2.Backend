using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services
{
    public interface IDataModelAdapter<TDataModel, TAggregateRoot>
        where TDataModel : BaseDataModel
        where TAggregateRoot : AggregateRoot
    {
        TAggregateRoot Adapt(TDataModel dataModel);

        TDataModel Adapt(TAggregateRoot aggregateRoot);
    }
}