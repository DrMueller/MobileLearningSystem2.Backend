using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModels.Models;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.Implementation
{
    public sealed class FactRepository : RepositoryBase<Fact, FactDataModel>, IFactRepository
    {
        private readonly IDataModelAdapter<FactDataModel, Fact> _dataModelAdapter;
        private readonly IDataModelRepository<FactDataModel> _dataModelRepository;

        public FactRepository(IDataModelRepository<FactDataModel> dataModelRepository, IDataModelAdapter<FactDataModel, Fact> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelAdapter = dataModelAdapter;
        }

        public async Task<IReadOnlyCollection<Fact>> LoadFactsByIds(IReadOnlyCollection<string> factIds)
        {
            var factModelsByIds = await _dataModelRepository.LoadAsync(f => factIds.Contains(f.Id));
            var result = factModelsByIds.Select(_dataModelAdapter.Adapt).ToList();
            return result;
        }
    }
}