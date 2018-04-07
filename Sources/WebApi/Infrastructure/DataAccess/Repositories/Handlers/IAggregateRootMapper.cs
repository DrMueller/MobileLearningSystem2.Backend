using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories.Handlers
{
    public interface IAggregateRootMapper<TAggregateRoot, TDataModel>
        where TAggregateRoot : AggregateRoot
        where TDataModel : BaseDataModel
    {
        TAggregateRoot Map(TDataModel dataModel);
    }
}