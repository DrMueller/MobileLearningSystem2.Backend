using Microsoft.Extensions.Options;
using Mmu.Mls2.WebApi.Infrastructure.Application.Settings.Models;

namespace Mmu.Mls2.WebApi.Infrastructure.Application.Settings.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _appSettingsOptions;

        public AppSettingsProvider(IOptions<AppSettings> appSettingsOptions)
        {
            _appSettingsOptions = appSettingsOptions;
        }

        public AppSettings GetAppSettings() => _appSettingsOptions.Value;
    }
}