﻿namespace Mmu.Mls2.WebApi.Infrastructure.ServiceProvisioning
{
    public static class ProvisioningServiceSingleton
    {
        public static IProvisioningService Instance { get; private set; }

        public static void Initialize(IProvisioningService instance)
        {
            Instance = instance;
        }
    }
}