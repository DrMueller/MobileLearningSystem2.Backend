using Microsoft.AspNetCore.Mvc;
using Mmu.Mls2.WebApi.Areas.Application.Services;

namespace Mmu.Mls2.WebApi.Areas.Web.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationInformationsController : Controller
    {
        private readonly IApplicationInformationFactory _applicationInformationFactory;

        public ApplicationInformationsController(IApplicationInformationFactory applicationInformationFactory)
        {
            _applicationInformationFactory = applicationInformationFactory;
        }

        [HttpGet]
        public IActionResult GetApplicationInformation()
        {
            var dto = _applicationInformationFactory.CreateApplicationInformation();
            return Ok(dto);
        }
    }
}