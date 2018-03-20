using System;

namespace Mmu.Mls2.WebApi.Infrastructure.Application.Aspects.Logging
{
    public interface ILoggingService
    {
        void LogException(Exception ex);

        void LogInfo(string message);

        void LogWarning(string message);
    }
}