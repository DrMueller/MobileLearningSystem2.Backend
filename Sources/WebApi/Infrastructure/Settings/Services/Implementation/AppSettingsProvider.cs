using Microsoft.Extensions.Options;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Models;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mls2.WebApi.Infrastructure.Settings.Models;

namespace Mmu.Mls2.WebApi.Infrastructure.Settings.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider, IDatabaseSettingsProvider
    {
        private readonly IOptions<AppSettings> _appSettingsOptions;

        public AppSettingsProvider(IOptions<AppSettings> appSettingsOptions)
        {
            _appSettingsOptions = appSettingsOptions;
        }

        public AppSettings ProvideAppSettings()
        {
            return _appSettingsOptions.Value;
        }

        public DatabaseSettings ProvideDatabaseSettings()
        {
            return _appSettingsOptions.Value.DatabaseSettings;
        }
    }
}