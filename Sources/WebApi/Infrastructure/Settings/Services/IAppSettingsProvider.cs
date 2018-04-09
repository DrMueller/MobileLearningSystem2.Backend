using Mmu.Mls2.WebApi.Infrastructure.Settings.Models;

namespace Mmu.Mls2.WebApi.Infrastructure.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings GetAppSettings();
    }
}