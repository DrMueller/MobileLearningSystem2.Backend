using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mls2.WebApi.Areas.Application.Dtos;
using Mmu.Mls2.WebApi.Areas.Application.Services;

namespace Mmu.Mls2.WebApi.Areas.Web.Controllers
{
    [Route("api/[controller]")]
    public class LearningSessionsController : Controller
    {
        private readonly ILearningSessionService _learningSessionService;

        public LearningSessionsController(ILearningSessionService learningSessionService) => _learningSessionService = learningSessionService;

        [HttpPost]
        public async Task<IActionResult> CreateLearningSessionAsync([FromBody] NewLearningSessionDto dto)
        {
            await _learningSessionService.CreateLearningSessionAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearningSessionAsync([FromRoute] string id)
        {
            await _learningSessionService.DeleteLearningSessionAsync(id);
            return Ok();
        }

        [HttpGet("{id}/Edit")]
        public async Task<IActionResult> GetLearningSessionByIdAsync([FromRoute] string id)
        {
            var factDto = await _learningSessionService.LoadLearningSessionEditByIdAsync(id);
            return Ok(factDto);
        }

        [HttpGet("Overview")]
        public async Task<IActionResult> GetLearningSessionOverviewEntriesAsync()
        {
            var allFactDtos = await _learningSessionService.LoadAllOverviewEntriesAsync();
            return Ok(allFactDtos);
        }

        [HttpGet("{id}/Run")]
        public async Task<IActionResult> LeadLearningSessionRunFacts([FromRoute] string id)
        {
            var dtos = await _learningSessionService.LoadLearningSessionRunFactsAsync(id);
            return Ok(dtos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLearningSessionEditAsync([FromBody] LearningSessionEditDto dto)
        {
            await _learningSessionService.UpdateLearningSessionEditAsync(dto);
            return Ok();
        }
    }
}