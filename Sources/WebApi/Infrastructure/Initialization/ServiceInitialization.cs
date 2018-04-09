using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mls2.WebApi.Infrastructure.Initialization.Handlers;
using Mmu.Mls2.WebApi.Infrastructure.ServiceProvisioning;
using Mmu.Mls2.WebApi.Infrastructure.Settings.Models;
using StructureMap;

namespace Mmu.Mls2.WebApi.Infrastructure.Initialization
{
    internal static class ServiceInitialization
    {
        internal static IServiceProvider InitializeServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddAutoMapper();
            InitializeAppSettings(services, configuration);
            InitializeCors(services);

            services.AddMvc();

            var result = CreateServiceProvider(services);
            return result;
        }

        private static IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            var container = ContainerInitialization.CreateInitializedContainer();

            container.Populate(services);
            var result = container.GetInstance<IServiceProvider>();
            var provisioningService = result.GetService<IProvisioningService>();

            ProvisioningServiceSingleton.Initialize(provisioningService);

            return result;
        }

        private static void InitializeAppSettings(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(AppSettings.SectionName));
            services.AddSingleton(configuration);
        }

        private static void InitializeCors(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "All",
                        builder =>
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials());
                });
        }
    }
}