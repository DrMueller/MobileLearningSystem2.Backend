﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services;
using Mmu.Mls2.WebApi.Infrastructure.ServiceProvisioning;
using Newtonsoft.Json;

namespace Mmu.Mls2.WebApi.Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await WriteExceptionAsync(context, ex, HttpStatusCode.InternalServerError).ConfigureAwait(false);
            }
        }

        private static void LogException(Exception exception)
        {
            // Seems like the Constructor here doesn't get invoked
            var loggingService = ProvisioningServiceSingleton.Instance.GetService<ILoggingService>();
            loggingService.LogException(exception);
        }

        private static Exception UnwrapException(Exception exception)
        {
            while (true)
            {
                var result = exception;
                if (result.InnerException == null || !(exception is AggregateException))
                {
                    return result;
                }

                exception = result.InnerException;
            }
        }

        // Careful, these properties are expected form the client, do not change on only one side
        private static async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;

            exception = UnwrapException(exception);
            LogException(exception);

            await response.WriteAsync(JsonConvert.SerializeObject(new { error = new { message = exception.Message, name = exception.GetType().Name, stack = exception.StackTrace } })).ConfigureAwait(false);
        }
    }
}