using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Auth;

namespace Wirtualnik.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenValidationParameters _tokenParameters;
        private readonly ILogger<AuthService> _logger;


        public AuthService(UserManager<ApplicationUser> userManager, TokenValidationParameters tokenParameters, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _tokenParameters = tokenParameters;
            _logger = logger;
        }

        public async Task<LoginResult> ExternalLoginAsync(AuthenticateResult auth)
        {
            var claims = auth.Principal.Identities.FirstOrDefault();
            var email = claims?.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                _logger.LogError("Facebook token does not contain email");
                return new LoginResult
                {
                    Success = false,
                    Errors = new[] { "User not logged in" }
                };
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                user = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                    Name = claims?.FindFirst(ClaimTypes.Name)?.Value,

                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    user = await _userManager.FindByEmailAsync(email);
                }
                else
                {
                    return new LoginResult
                    {
                        Success = false,
                        Errors = result.Errors.Select(e => e.Description)
                    };
                }
            }

            if (!await _userManager.IsInRoleAsync(user, "Member"))
            {
                await _userManager.AddToRoleAsync(user, "Member");
                user = await _userManager.FindByEmailAsync(email);
            }

            var token = await GenerateToken(user);
            if (token is null)
            {
                _logger.LogError($"Token generation failed for user: { user.Email }. Provider: Facebook");
                return new LoginResult
                {
                    Success = false,
                    Errors = new[] { "Authentication error" }
                };
            }

            return new LoginResult
            {
                Success = true,
                Token = token
            };
        }

        public async Task<LoginResult> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null) return new LoginResult
            {
                Success = false,
                Errors = new[] { "Login or password is invalid" }
            };

            var valid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!valid) return new LoginResult
            {
                Success = false,
                Errors = new[] { "Login or password is invalid" }
            };

            var token = await GenerateToken(user);

            if (token is null)
            {
                _logger.LogError($"Token generation failed for user: { user.Email }. Provider: Password login");
            }

            return new LoginResult
            {
                Success = true,
                Token = token
            };
        }

        private async Task<string?> GenerateToken(ApplicationUser user)
        {
            var roles = await GetUserRoles(user);

            if (roles is null)
            {
                _logger.LogError($"User:{user.Email}, is not assigned to any role");
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new Claim(JwtRegisteredClaimNames.GivenName, user.Name ?? string.Empty),
                    new Claim("role", roles)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(_tokenParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }


        private async Task<string?> GetUserRoles(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Count == 0)
            {
                return null;
            }

            return roles.Aggregate((cur, next) => cur + "," + next);
        }
    }
}
