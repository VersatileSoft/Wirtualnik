using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Wirtualnik.Server.Extensions.Middlewares
{
    public class ApiLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration config;
        private readonly ILogger<ApiLoggingMiddleware> logger;

        #region ApiLoggingMiddleware()
        public ApiLoggingMiddleware(RequestDelegate next, IConfiguration config, ILogger<ApiLoggingMiddleware> logger)
        {
            this.next = next;
            this.config = config;
            this.logger = logger;
        }
        #endregion

        #region Invoke()
        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context.Request);
            await next.Invoke(context);
            await LogResponse(context.Response);
        }
        #endregion

        #region LogRequest()
        private async Task LogRequest(HttpRequest request)
        {
            if (bool.TryParse(config["NLog:Api:Logging"], out bool value) && value)
            {
                request.Headers.TryGetValue("Accept", out var accept);
                request.Headers.TryGetValue("Content-Type", out var type);

                var logBody = accept.Any(p => p.Contains("json")) && !type.Any(p => p.Contains("multipart/form-data"));
                var content = "{}";

                if (logBody)
                {
                    request.Body.Position = 0;

                    var reader = new StreamReader(request.Body);
                    var bodyAsText = await reader.ReadToEndAsync();

                    if (!string.IsNullOrWhiteSpace(bodyAsText))
                    {
                        content = bodyAsText;
                    }

                    request.Body.Position = 0;
                }

                logger.LogInformation(
                    "{RequestType} HttpMethod: {Method}, Path: {Path}, Headers: {Headers}, Body: {Body}",
                    "REQUEST",
                    request.Method,
                    request.Path,
                    request.Headers,
                    content
                );
            }
        }
        #endregion

        #region LogResponse()
        private async Task LogResponse(HttpResponse response)
        {
            if (bool.TryParse(config["NLog:Api:Logging"], out bool value) && value)
            {
                response.Headers.TryGetValue("Content-Type", out var contentType);

                var logBody = contentType.Any(p => p.Contains("json"));
                var content = "{}";

                if (logBody)
                {
                    response.Body.Position = 0;

                    var reader = new StreamReader(response.Body);
                    var bodyAsText = await reader.ReadToEndAsync();

                    if (!string.IsNullOrWhiteSpace(bodyAsText))
                    {
                        content = bodyAsText;
                    }

                    response.Body.Position = 0;
                }

                logger.LogInformation(
                    "{RequestType} StatusCode: {StatusCode}, Headers: {Headers}, Body: {Body}",
                    "RESPONSE",
                    response.StatusCode,
                    response.Headers,
                    content
                );
            }
        }
        #endregion
    }
}