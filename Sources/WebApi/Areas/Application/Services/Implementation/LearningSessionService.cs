using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mls2.WebApi.Areas.Application.Dtos;
using Mmu.Mls2.WebApi.Areas.DataAccess.Repositories;
using Mmu.Mls2.WebApi.Areas.Domain.Factories;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories;

namespace Mmu.Mls2.WebApi.Areas.Application.Services.Implementation
{
    public class LearningSessionService : ILearningSessionService
    {
        private readonly IFactRepository _factRepository;
        private readonly ILearningSessionFactory _learningSessionFactory;
        private readonly IRepository<LearningSession> _learningSessionRepository;
        private readonly IMapper _mapper;

        public LearningSessionService(
            IMapper mapper,
            ILearningSessionFactory learningSessionFactory,
            IRepository<LearningSession> learningSessionRepository,
            IFactRepository factRepository)
        {
            _mapper = mapper;
            _learningSessionFactory = learningSessionFactory;
            _learningSessionRepository = learningSessionRepository;
            _factRepository = factRepository;
        }

        public async Task<LearningSessionDto> CreateLearningSessionAsync(LearningSessionDto dto)
        {
            var learningSession = _learningSessionFactory.CreateLearningSession(dto.SessionName);
            var learningSessionFromDb = await _learningSessionRepository.SaveAsync(learningSession);

            var result = _mapper.Map<LearningSessionDto>(learningSessionFromDb);
            return result;
        }

        public async Task DeleteLearningSessionAsync(string id)
        {
            Guard.StringNotNullOrEmpty(() => id);
            await _learningSessionRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<LearningSessionDto>> LoadAllLearningSessionAsync()
        {
            var allLearningSessions = await _learningSessionRepository.LoadAllAsync();
            var result = _mapper.Map<List<LearningSessionDto>>(allLearningSessions);

            return result;
        }

        public async Task<IReadOnlyCollection<FactDto>> LoadFactsAsync(string learningSessionId)
        {
            var learningSession = await _learningSessionRepository.LoadByIdAsync(learningSessionId);
            if (learningSession.FactIds == null || !learningSession.FactIds.Any())
            {
                return new List<FactDto>();
            }

            var facts = await _factRepository.LoadFactsByIds(learningSession.FactIds);
            var result = _mapper.Map<List<FactDto>>(facts);

            return result;
        }

        public async Task<LearningSessionDto> LoadLearningSessionByIdAsync(string id)
        {
            var learningSession = await _learningSessionRepository.LoadByIdAsync(id);
            var result = _mapper.Map<LearningSessionDto>(learningSession);

            return result;
        }

        public async Task UpdateFactsAsync(string learningSessionId, IReadOnlyCollection<FactDto> facts)
        {
            Guard.StringNotNullOrEmpty(() => learningSessionId);
            var learningSession = await _learningSessionRepository.LoadByIdAsync(learningSessionId);

            var factIds = facts.Select(f => f.Id).ToList();
            learningSession.AlignFacts(factIds);

            await _learningSessionRepository.SaveAsync(learningSession);
        }

        public async Task<LearningSessionDto> UpdateLearningSessionAsync(LearningSessionDto dto)
        {
            Guard.StringNotNullOrEmpty(() => dto.Id);

            var learningSession = await _learningSessionRepository.LoadByIdAsync(dto.Id);
            _mapper.Map(dto, learningSession);

            var learningSessionFromDb = await _learningSessionRepository.SaveAsync(learningSession);
            var result = _mapper.Map<LearningSessionDto>(learningSessionFromDb);
            return result;
        }
    }
}