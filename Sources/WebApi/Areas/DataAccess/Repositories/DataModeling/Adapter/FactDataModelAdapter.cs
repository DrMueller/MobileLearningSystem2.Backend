using AutoMapper;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModeling.Models;
using Mmu.Mls2.WebApi.Areas.Domain.Factories;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModeling.Adapter
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