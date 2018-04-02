using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mls2.WebApi.Areas.Application.Dtos;

namespace Mmu.Mls2.WebApi.Areas.Application.Services
{
    public interface ILearningSessionService
    {
        Task<LearningSessionDto> CreateLearningSessionAsync(LearningSessionDto dto);

        Task DeleteLearningSessionAsync(string id);

        Task<IReadOnlyCollection<LearningSessionDto>> LoadAllLearningSessionAsync();

        Task<IReadOnlyCollection<FactDto>> LoadFactsAsync(string learningSessionId);

        Task<LearningSessionDto> LoadLearningSessionByIdAsync(string id);

        Task UpdateFactsAsync(string learningSessionId, IReadOnlyCollection<FactDto> facts);

        Task<LearningSessionDto> UpdateLearningSessionAsync(LearningSessionDto dto);
    }
}