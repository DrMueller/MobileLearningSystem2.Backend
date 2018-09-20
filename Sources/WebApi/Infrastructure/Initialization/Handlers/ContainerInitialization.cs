using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using StructureMap;

namespace Mmu.Mls2.WebApi.Infrastructure.Initialization.Handlers
{
    public static class ContainerInitialization
    {
        public static Container CreateInitializedContainer()
        {
            var result = ContainerInitializationService.CreateInitializedContainer(
                new AssemblyParameters(typeof(ContainerInitialization).Assembly, "Mmu.Mls"));
            return result;
        }
    }
}