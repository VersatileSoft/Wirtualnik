using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Server.Extensions.Settings;

namespace Wirtualnik.Server.Extensions.Swagger
{
    public class SwaggerAuthorizedMiddleware
    {
        private readonly RequestDelegate _next;
        protected SwaggerSettings Settings { get; set; }

        public SwaggerAuthorizedMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            Settings = new SwaggerSettings(config);
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (!Settings.Authorized)
            {
                await _next.Invoke(httpContext);
                return;
            }

            if (httpContext.Request.Path.StartsWithSegments("/swagger"))
            {
                var header = httpContext.Request.Headers["Authorization"];

                if (!string.IsNullOrWhiteSpace(header))
                {
                    AuthenticationHeaderValue authValues = AuthenticationHeaderValue.Parse(header);

                    if ("Basic".Equals(authValues.Scheme, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var parameter = Encoding.UTF8.GetString(Convert.FromBase64String(authValues.Parameter ?? ""));
                        var parts = parameter.Split(':');

                        if (parts.Length > 1)
                        {
                            string username = parts[0];
                            string password = parameter.Substring(username.Length + 1);

                            if (!string.IsNullOrWhiteSpace(username)
                                && !string.IsNullOrWhiteSpace(password)
                                && username == Settings.Username
                                && password == Settings.Password)
                            {
                                await _next.Invoke(httpContext);
                                return;
                            }
                        }
                    }
                }

                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                httpContext.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"Swagger UI\"");
                await httpContext.Response.WriteAsync("Authentication is required.");
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }
}