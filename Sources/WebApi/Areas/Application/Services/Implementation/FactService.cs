using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mls2.WebApi.Areas.Application.Dtos;
using Mmu.Mls2.WebApi.Areas.Domain.Factories;
using Mmu.Mls2.WebApi.Areas.Domain.Models;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories;

namespace Mmu.Mls2.WebApi.Areas.Application.Services.Implementation
{
    public class FactService : IFactService
    {
        private readonly IFactFactory _factFactory;
        private readonly IRepository<Fact> _factRepository;
        private readonly IMapper _mapper;

        public FactService(
            IMapper mapper,
            IFactFactory factFactory,
            IRepository<Fact> factRepository)
        {
            _mapper = mapper;
            _factFactory = factFactory;
            _factRepository = factRepository;
        }

        public async Task CreateFactAsync(NewFactDto dto)
        {
            var fact = _factFactory.CreateFact(dto.QuestionText, dto.AnswerText);
            await _factRepository.SaveAsync(fact);
        }

        public async Task DeleteFactAsync(string id)
        {
            Guard.StringNotNullOrEmpty(() => id);

            await _factRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<FactDto>> LoadAllFactsAsync()
        {
            var allFacts = await _factRepository.LoadAllAsync();
            var result = _mapper.Map<List<FactDto>>(allFacts);

            return result;
        }

        public async Task<FactDto> LoadFactByIdAsync(string id)
        {
            var fact = await _factRepository.LoadByIdAsync(id);
            var result = _mapper.Map<FactDto>(fact);

            return result;
        }

        public async Task UpdateFactAsync(FactDto dto)
        {
            Guard.StringNotNullOrEmpty(() => dto.Id);

            var fact = await _factRepository.LoadByIdAsync(dto.Id);
            _mapper.Map(dto, fact);
            await _factRepository.SaveAsync(fact);
        }
    }
}