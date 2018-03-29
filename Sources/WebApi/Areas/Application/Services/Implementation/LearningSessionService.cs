using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mls2.WebApi.Areas.Application.Dtos;
using Mmu.Mls2.WebApi.Areas.Domain.Factories;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories;

namespace Mmu.Mls2.WebApi.Areas.Application.Services.Implementation
{
    public class LearningSessionService : ILearningSessionService
    {
        private readonly IRepository<Fact> _factRepository;
        private readonly ILearningSessionFactory _learningSessionFactory;
        private readonly IRepository<LearningSession> _learningSessionRepository;
        private readonly IMapper _mapper;

        public LearningSessionService(
            IMapper mapper,
            ILearningSessionFactory learningSessionFactory,
            IRepository<LearningSession> learningSessionRepository,
            IRepository<Fact> factRepository)
        {
            _mapper = mapper;
            _learningSessionFactory = learningSessionFactory;
            _learningSessionRepository = learningSessionRepository;
            _factRepository = factRepository;
        }

        public async Task CreateLearningSessionAsync(NewLearningSessionDto dto)
        {
            var learningSession = _learningSessionFactory.CreateLearningSession(dto.SessionName);
            await _learningSessionRepository.SaveAsync(learningSession);
        }

        public async Task DeleteLearningSessionAsync(string id)
        {
            Guard.StringNotNullOrEmpty(() => id);
            await _learningSessionRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<LearningSessionOverviewEntryDto>> LoadAllOverviewEntriesAsync()
        {
            var allLearningSessions = await _learningSessionRepository.LoadAllAsync();
            var result = _mapper.Map<List<LearningSessionOverviewEntryDto>>(allLearningSessions);

            return result;
        }

        public async Task<LearningSessionEditDto> LoadLearningSessionEditByIdAsync(string id)
        {
            var learningSession = await _learningSessionRepository.LoadByIdAsync(id);
            var result = _mapper.Map<LearningSessionEditDto>(learningSession);

            return result;
        }

        public async Task<IReadOnlyCollection<LearningSessionRunFactDto>> LoadLearningSessionRunFactsAsync(string learningSessionId)
        {
            var learningSession = await _learningSessionRepository.LoadByIdAsync(learningSessionId);
            if (learningSession.FactIds == null || !learningSession.FactIds.Any())
            {
                return new List<LearningSessionRunFactDto>();
            }

            var facts = await _factRepository.LoadAsync(f => learningSession.FactIds.Contains(f.Id));
            var result = _mapper.Map<List<LearningSessionRunFactDto>>(facts);

            return result;
        }

        public async Task UpdateLearningSessionEditAsync(LearningSessionEditDto dto)
        {
            Guard.StringNotNullOrEmpty(() => dto.Id);

            var learningSession = await _learningSessionRepository.LoadByIdAsync(dto.Id);
            _mapper.Map(dto, learningSession);

            learningSession.AlignFacts(dto.FactIds);

            await _learningSessionRepository.SaveAsync(learningSession);
        }
    }
}