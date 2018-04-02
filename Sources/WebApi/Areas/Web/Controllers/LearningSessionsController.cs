using System.Collections.Generic;
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
        public async Task<IActionResult> CreateLearningSessionAsync([FromBody] LearningSessionDto dto)
        {
            var createdlearningSession = await _learningSessionService.CreateLearningSessionAsync(dto);
            return Ok(createdlearningSession);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearningSessionAsync([FromRoute] string id)
        {
            await _learningSessionService.DeleteLearningSessionAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLearningSessionByIdAsync([FromRoute] string id)
        {
            var factDto = await _learningSessionService.LoadLearningSessionByIdAsync(id);
            return Ok(factDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLearningSessionsAsync()
        {
            var allFactDtos = await _learningSessionService.LoadAllLearningSessionAsync();
            return Ok(allFactDtos);
        }

        [HttpGet("{id}/Facts")]
        public async Task<IActionResult> LoadLearningSessionFactsAsync([FromRoute] string id)
        {
            var dtos = await _learningSessionService.LoadFactsAsync(id);
            return Ok(dtos);
        }

        [HttpPut("{id}/Facts")]
        public async Task<IActionResult> UpdateLearningSessionFactsAsync([FromRoute] string id, [FromBody] List<FactDto> factDtos)
        {
            await _learningSessionService.UpdateFactsAsync(id, factDtos);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLearningSessionAsync([FromBody] LearningSessionDto dto)
        {
            var updatedLearningSession = await _learningSessionService.UpdateLearningSessionAsync(dto);
            return Ok(updatedLearningSession);
        }
    }
}