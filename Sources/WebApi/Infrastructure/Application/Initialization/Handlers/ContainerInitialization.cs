using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Mmu.Mlh.DataAccess.Areas.DataMapping.Services;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using StructureMap;

namespace Mmu.Mls2.WebApi.Infrastructure.Application.Initialization.Handlers
{
    public static class ContainerInitialization
    {
        public static Container CreateInitializedContainer()
        {
            var result = new Container();

            var assemblyReferences = GetAllAssemblyReferences(typeof(ContainerInitialization).Assembly);

            result.Configure(
                config =>
                {
                    config.Scan(
                        scan =>
                        {
                            scan.AssemblyContainingType(typeof(ContainerInitialization));

                            foreach (var assemblyReference in assemblyReferences)
                            {
                                scan.Assembly(assemblyReference);
                            }

                            scan.AddAllTypesOf(typeof(IRepository<>));
                            scan.AddAllTypesOf(typeof(IDataModelAdapter<,>));
                            scan.AddAllTypesOf<IDataMapper>();
                            scan.LookForRegistries();
                            scan.WithDefaultConventions();
                        });

                    config.For<IHttpContextAccessor>().Use<HttpContextAccessor>().Singleton();
                });

            return result;
        }

        private static IReadOnlyCollection<Assembly> GetAllAssemblyReferences(Assembly assembly)
        {
            var result = new List<Assembly>();
            GetReferences(assembly, result);

            return result;
        }

        private static void GetReferences(Assembly sourceAssembly, ICollection<Assembly> references)
        {
            foreach (var assemblyName in sourceAssembly.GetReferencedAssemblies())
            {
                var referencedAssembly = AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .SingleOrDefault(a => a.GetName().FullName == assemblyName.FullName);

                if (referencedAssembly == null || references.Contains(referencedAssembly))
                {
                    continue;
                }

                ////GetReferences(referencedAssembly, references);
                references.Add(referencedAssembly);
            }
        }
    }
}