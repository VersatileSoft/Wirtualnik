using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Server.Extensions.Swagger
{
    public class SwaggerAuthorizedMiddleware
    {
        private readonly RequestDelegate _next;
        protected AppSettings Settings { get; set; }

        public SwaggerAuthorizedMiddleware(RequestDelegate next, AppSettings settings)
        {
            _next = next;
            Settings = settings;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
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
                                && username == Settings.Swagger?.Username
                                && password == Settings.Swagger?.Password)
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

    public static class SwaggerExtensions
    {
        public static void UseExtSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseMiddleware<SwaggerAuthorizedMiddleware>();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wirtualnik"));
        }
    }

    public class SwaggerSettings
    {
        public bool Enabled { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool Authorized { get; set; }
    }
}
