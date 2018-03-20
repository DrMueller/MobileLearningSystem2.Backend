﻿using System;
using Mmu.Mls2.WebApi.Infrastructure.Application.Aspects.Logging.Handlers;
using Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.Invariance;

namespace Mmu.Mls2.WebApi.Infrastructure.Application.Aspects.Logging.Implementation
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggerProxy _logProxy;

        public LoggingService(ILoggerProxy logProxy)
        {
            _logProxy = logProxy;
        }

        public void LogException(Exception ex)
        {
            Guard.ObjectNotNull(() => ex);
            _logProxy.LogError(ex, ex.Message);
        }

        public void LogInfo(string message)
        {
            Guard.StringNotNullOrEmpty(() => message);
            _logProxy.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            Guard.StringNotNullOrEmpty(() => message);
            _logProxy.LogWarning(message);
        }
    }
}