using System;
using Microsoft.AspNetCore.Http;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DataMapping.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using Mmu.Mls2.WebApi.Infrastructure.Settings.Services.Implementation;
using StructureMap;
using StructureMap.Graph;

namespace Mmu.Mls2.WebApi.Infrastructure.Initialization.Handlers
{
    public static class ContainerInitialization
    {
        public static Container CreateInitializedContainer()
        {
            var result = ContainerInitializationService.CreateInitializedContainer(typeof(ContainerInitialization).Assembly);
            return result;
        }
    }
}