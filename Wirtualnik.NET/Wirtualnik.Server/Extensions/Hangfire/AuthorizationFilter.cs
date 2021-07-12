using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Wirtualnik.Server.Extensions.Settings;

namespace Wirtualnik.Server.Extensions.Hangfire
{


    public class AuthorizationFilter : IDashboardAuthorizationFilter
    {
        private readonly HangfireSettings _settings;

        #region AuthorizationFilter()
        public AuthorizationFilter(HangfireSettings settings)
        {
            _settings = settings;
        }
        #endregion

        #region Authorize()
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var header = httpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrWhiteSpace(header))
            {
                AuthenticationHeaderValue authValues = AuthenticationHeaderValue.Parse(header);

                if ("Basic".Equals(authValues.Scheme, StringComparison.InvariantCultureIgnoreCase))
                {
                    var parameter = Encoding.UTF8.GetString(Convert.FromBase64String(authValues.Parameter));
                    var parts = parameter.Split(':');

                    if (parts.Length > 1)
                    {
                        string username = parts[0];
                        string password = parameter.Substring(username.Length + 1);

                        if (!string.IsNullOrWhiteSpace(username) &&
                            !string.IsNullOrWhiteSpace(password) &&
                            username == _settings?.Dashboard?.Username &&
                            password == _settings.Dashboard.Password)
                        {
                            return true;
                        }
                    }
                }
            }

            return Challenge(httpContext);
        }
        #endregion

        private bool Challenge(HttpContext context)
        {
            context.Response.StatusCode = 401;
            context.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"Hangfire Dashboard\"");
            context.Response.WriteAsync("Authentication is required.");

            return false;
        }
    }

}