using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Extensions.Settings;

namespace Wirtualnik.Server.Extensions.Authentication
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
        {
            var authSettings = new AuthenticationSettings(config);

            services.AddSingleton(authSettings);

            var tokenParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authSettings.JwtAuthenticationSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };

            services.AddSingleton(tokenParams);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenParams;
            })
            .AddCookie()
            .AddFacebook(opt =>
            {
                opt.AppId = authSettings.FacebookAuthenticationSettings.AppId;
                opt.AppSecret = authSettings.FacebookAuthenticationSettings.AppSecret;
                opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddAuthorization();

            return services;
        }

        public static async Task InitializeAuth(this IServiceProvider serviceProvider, IConfiguration config)
        {
            var authSettings = new AuthenticationSettings(config);
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Member" };

            foreach (var roleName in roleNames)
            {
                if (!(await RoleManager.RoleExistsAsync(roleName)))
                {
                    await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            if (await UserManager.FindByEmailAsync(authSettings?.AdminUser?.Email ?? "admin@wirtualnik.pl") is null)
            {
                var admin = new ApplicationUser
                {
                    UserName = authSettings?.AdminUser?.Email ?? "admin@admin.pl",
                    Email = authSettings?.AdminUser?.Email ?? "admin@admin.pl",
                    Name = "Admin Admin"
                };

                var result = await UserManager.CreateAsync(admin, authSettings?.AdminUser?.Password ?? "admin");

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}