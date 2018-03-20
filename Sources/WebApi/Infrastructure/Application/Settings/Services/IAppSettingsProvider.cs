using Mmu.Mls2.WebApi.Infrastructure.Application.Settings.Models;

namespace Mmu.Mls2.WebApi.Infrastructure.Application.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings GetAppSettings();
    }
}