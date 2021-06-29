using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Wirtualnik.Server.Extensions.Middlewares
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RequestTimeMiddleware> logger;

        #region RequestTimeLoggingMiddleware()
        public RequestTimeMiddleware(RequestDelegate next, ILogger<RequestTimeMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        #endregion

        #region Invoke()
        public async Task Invoke(HttpContext context)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                await next(context);

                sw.Stop();

                var statusCode = context.Response?.StatusCode;

                if (statusCode < 500)
                    LogRequest(LogLevel.Information, context, sw, statusCode);
                else
                    LogRequest(LogLevel.Error, context, sw, statusCode);
            }
            catch (Exception ex)
            {
                sw.Stop();

                logger.LogError(ex, ex.Message);

                LogRequest(LogLevel.Error, context, sw, 500);
            }
        }
        #endregion

        #region LogRequest()
        private void LogRequest(LogLevel logLevel, HttpContext context, Stopwatch sw, int? statusCode)
        {
            logger.Log(
                logLevel,
                "{RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0}ms",
                context.Request.Method,
                context.Request.Path,
                statusCode,
                sw.Elapsed.TotalMilliseconds
            );
        }
        #endregion
    }
}
