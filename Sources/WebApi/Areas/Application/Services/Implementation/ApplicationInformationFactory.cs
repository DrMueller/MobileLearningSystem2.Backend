using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Application.Services.Implementation
{
    public class ApplicationInformationFactory : IApplicationInformationFactory
    {
        public ApplicationInformationDto CreateApplicationInformation()
        {
            var applicationVersion = typeof(ApplicationInformationFactory).Assembly.GetName().Version.ToString();
            var result = new ApplicationInformationDto
            {
                ApplicationVersion = applicationVersion,
                ApplicationTitle = "MLS 2"
            };

            return result;
        }
    }
}