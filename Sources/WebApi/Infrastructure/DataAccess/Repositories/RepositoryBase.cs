﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.DomainModels;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services;

namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories
{
    public abstract class RepositoryBase<TAggregateRoot, TDataModel> : IRepository<TAggregateRoot>
        where TAggregateRoot : AggregateRoot
        where TDataModel : BaseDataModel
    {
        private readonly IDataModelAdapter<TDataModel, TAggregateRoot> _dataModelAdapter;
        private readonly IDataModelRepository<TDataModel> _dataModelRepository;

        protected RepositoryBase(IDataModelRepository<TDataModel> dataModelRepository, IDataModelAdapter<TDataModel, TAggregateRoot> dataModelAdapter)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelAdapter = dataModelAdapter;
        }

        public async Task DeleteAsync(string id)
        {
            await _dataModelRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<TAggregateRoot>> LoadAllAsync()
        {
            var allDataModels = await _dataModelRepository.LoadAsync(f => true);
            var result = allDataModels.Select(_dataModelAdapter.Adapt).ToList();
            return result;
        }

        public async Task<TAggregateRoot> LoadByIdAsync(string id)
        {
            var dataModel = await _dataModelRepository.LoadSingleAsync(f => f.Id == id);
            var aggregateRoot = _dataModelAdapter.Adapt(dataModel);
            return aggregateRoot;
        }

        public async Task<TAggregateRoot> SaveAsync(TAggregateRoot aggregateRoot)
        {
            var dataModel = _dataModelAdapter.Adapt(aggregateRoot);
            var returnedDataModel = await _dataModelRepository.SaveAsync(dataModel);

            var result = _dataModelAdapter.Adapt(returnedDataModel);
            return result;
        }
    }
}