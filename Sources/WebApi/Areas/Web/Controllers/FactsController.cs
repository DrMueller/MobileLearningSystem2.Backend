﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mls2.WebApi.Areas.Application.Dtos;
using Mmu.Mls2.WebApi.Areas.Application.Services;

namespace Mmu.Mls2.WebApi.Areas.Web.Controllers
{
    [Route("api/[controller]")]
    public class FactsController : Controller
    {
        private readonly IFactService _factService;

        public FactsController(IFactService factService)
        {
            _factService = factService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFactAsync([FromBody] FactDto dto)
        {
            await _factService.CreateFactAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactAsync([FromRoute] string id)
        {
            await _factService.DeleteFactAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFactsAsync()
        {
            var allFactDtos = await _factService.LoadAllFactsAsync();
            return Ok(allFactDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFactByIdAsync([FromRoute] string id)
        {
            var factDto = await _factService.LoadFactbyIdAsync(id);
            return Ok(factDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFactAsync([FromBody] FactDto dto)
        {
            await _factService.UpdateFactAsync(dto);
            return Ok();
        }
    }
}