using Mmu.Mls2.WebApi.Areas.Application.Dtos;

namespace Mmu.Mls2.WebApi.Areas.Application.Services
{
    public interface IApplicationInformationFactory
    {
        ApplicationInformationDto CreateApplicationInformation();
    }
}