using Microsoft.AspNetCore.Http;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataMapping;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataMapping.Implementation;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services.Handlers;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Services.Handlers.Implemention;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.Repositories.Implementation;
using StructureMap;

namespace Mmu.Mls2.WebApi.Infrastructure.Application.Initialization.Handlers
{
    public static class ContainerInitialization
    {
        public static Container CreateInitializedContainer()
        {
            var result = new Container();

            result.Configure(
                config =>
                {
                    config.Scan(
                        scan =>
                        {
                            // Fun fact: TheCallingAssembly doesn't work in AspNet Core
                            scan.AssemblyContainingType(typeof(ContainerInitialization));

                            scan.AddAllTypesOf(typeof(IRepository<>));
                            scan.AddAllTypesOf(typeof(IMongoDbFilterDefinitionFactory<>));
                            scan.AddAllTypesOf(typeof(IDataModelRepository<>));
                            scan.AddAllTypesOf(typeof(IDataModelAdapter<,>));
                            scan.AddAllTypesOf<IDataMapper>();
                            scan.WithDefaultConventions();
                        });

                    config.For<IRepositoryFactory>().Use<RepositoryFactory>().Singleton();

                    config.For<IHttpContextAccessor>().Use<HttpContextAccessor>().Singleton();
                });

            return result;
        }
    }
}