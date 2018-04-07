using AutoMapper;
using Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModels.Models;
using Mmu.Mls2.WebApi.Areas.Domain.Factories;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModels.Adapter
{
    public class FactDataModelAdapter : IDataModelAdapter<FactDataModel, Fact>
    {
        private readonly IFactFactory _factFactory;
        private readonly IMapper _mapper;

        public FactDataModelAdapter(IFactFactory factFactory, IMapper mapper)
        {
            _factFactory = factFactory;
            _mapper = mapper;
        }

        public Fact Adapt(FactDataModel dataModel) => _factFactory.CreateFact(dataModel.Id, dataModel.QuestionText, dataModel.AnswerText);

        public FactDataModel Adapt(Fact aggregateRoot) => _mapper.Map<FactDataModel>(aggregateRoot);
    }
}