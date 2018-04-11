using Microsoft.AspNetCore.Http;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DataMapping.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Mls2.WebApi.Infrastructure.Settings.Services.Implementation;
using StructureMap;

namespace Mmu.Mls2.WebApi.Infrastructure.DependencyInjection
{
    public class WebApiRegistry : Registry
    {
        public WebApiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WebApiRegistry>();
                    scanner.AddAllTypesOf(typeof(IRepository<>));
                    scanner.AddAllTypesOf(typeof(IDataModelAdapter<,>));
                    scanner.AddAllTypesOf<IDataMapper>();
                });

            For<IHttpContextAccessor>().Use<HttpContextAccessor>().Singleton();
            For<IDatabaseSettingsProvider>().Use<AppSettingsProvider>();
        }
    }
}