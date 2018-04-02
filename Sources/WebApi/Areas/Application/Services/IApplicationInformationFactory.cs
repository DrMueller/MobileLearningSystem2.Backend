using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Application.Services
{
    public interface IApplicationInformationFactory
    {
        ApplicationInformationDto CreateApplicationInformation();
    }
}