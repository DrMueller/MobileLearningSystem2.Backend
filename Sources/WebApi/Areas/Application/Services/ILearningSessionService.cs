using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mls2.WebApi.Areas.Application.Dtos;

namespace Mmu.Mls2.WebApi.Areas.Application.Services
{
    public interface ILearningSessionService
    {
        Task CreateLearningSessionAsync(NewLearningSessionDto dto);

        Task DeleteLearningSessionAsync(string id);

        Task<IReadOnlyCollection<LearningSessionOverviewEntryDto>> LoadAllOverviewEntriesAsync();

        Task<LearningSessionEditDto> LoadLearningSessionEditByIdAsync(string id);

        Task<IReadOnlyCollection<LearningSessionRunFactDto>> LoadLearningSessionRunFactsAsync(string learningSessionId);

        Task UpdateLearningSessionEditAsync(LearningSessionEditDto dto);
    }
}