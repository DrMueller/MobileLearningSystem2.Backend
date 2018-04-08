using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModeling.Models;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

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