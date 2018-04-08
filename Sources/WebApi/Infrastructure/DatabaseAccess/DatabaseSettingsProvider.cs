using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Models;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mls2.WebApi.Infrastructure.Application.Settings.Services;

namespace Mmu.Mls2.WebApi.Infrastructure.DatabaseAccess
{
    public class DatabaseSettingsProvider : IDatabaseSettingsProvider
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public DatabaseSettingsProvider(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public DatabaseSettings ProvideSettings()
        {
            return _appSettingsProvider.GetAppSettings().DatabaseSettings;
        }
    }
}
