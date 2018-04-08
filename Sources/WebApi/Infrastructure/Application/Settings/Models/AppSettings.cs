using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Models;

namespace Mmu.Mls2.WebApi.Infrastructure.Application.Settings.Models
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";
        public DatabaseSettings DatabaseSettings { get; set; }
        public SecuritySettings SecuritySettings { get; set; }
    }
}