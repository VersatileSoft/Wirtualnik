using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Wirtualnik.Server.Extensions.Settings;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Auth;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        private readonly AuthenticationSettings _authSettings;

        public AuthController(IAuthService authService, ILogger<AuthController> logger, AuthenticationSettings authSettings)
        {
            _authService = authService;
            _logger = logger;
            _authSettings = authSettings;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> LoginAsync(LoginModel model)
        {
            var loginResult = await _authService.LoginAsync(model);

            return Ok(loginResult);
        }

        [HttpGet("login/{scheme}")]
        public async Task<ActionResult> FacebookAuthenticateAsync(string scheme)
        {
            if (scheme.Length > 0)
                scheme = char.ToUpper(scheme[0]) + scheme.Substring(1);

            AuthenticateResult auth;
            try
            {
                auth = await Request.HttpContext.AuthenticateAsync(scheme);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, $"Invalid external auth scheme: {scheme}");
                return Redirect(_authSettings.ErrorUrl);
            }

            if (!auth.Succeeded)
                return Challenge(scheme);

            var result = await _authService.ExternalLoginAsync(auth);
            await Request.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (result.Success)
            {
                return Redirect($"{_authSettings.CallbackUrl}#access_token={result.Token}");
            }
            else
            {
                return Redirect(_authSettings.ErrorUrl);
            }
        }
    }
}