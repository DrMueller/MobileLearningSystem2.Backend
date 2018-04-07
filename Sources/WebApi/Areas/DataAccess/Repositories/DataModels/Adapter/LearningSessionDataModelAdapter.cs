using AutoMapper;
using Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModels.Models;
using Mmu.Mls2.WebApi.Areas.Domain.Factories;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModels.Adapter
{
    public class LearningSessionDataModelAdapter : IDataModelAdapter<LearningSessionDataModel, LearningSession>
    {
        private readonly ILearningSessionFactory _learningSessionFactory;
        private readonly IMapper _mapper;

        public LearningSessionDataModelAdapter(ILearningSessionFactory learningSessionFactory, IMapper mapper)
        {
            _learningSessionFactory = learningSessionFactory;
            _mapper = mapper;
        }

        public LearningSession Adapt(LearningSessionDataModel dataModel) => _learningSessionFactory.CreateLearningSession(dataModel.Id, dataModel.SessionName, dataModel.FactIds);

        public LearningSessionDataModel Adapt(LearningSession aggregateRoot) => _mapper.Map<LearningSessionDataModel>(aggregateRoot);
    }
}