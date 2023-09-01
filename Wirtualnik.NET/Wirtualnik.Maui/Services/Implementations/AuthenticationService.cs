using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Wirtualnik.Maui.Pages;

namespace Wirtualnik.Maui.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string authBaseUrl = "https://api.zlcn.pro/auth/login/";
        private const string authUrlParam = "?callbackType=mobile";

        private readonly MainPage mainPage;
        private readonly INavigationService navigationService;

        public AuthenticationService(MainPage mainPage, INavigationService navigationService)
        {
            this.mainPage = mainPage;
            this.navigationService = navigationService;
        }

        public async Task<bool> SignInAsync(string? provider)
        {
            var authToken = string.Empty;
            WebAuthenticatorResult? result = null;

            try
            {
                if (string.IsNullOrEmpty(provider) || (provider.Equals("Apple") && DeviceInfo.Platform == DevicePlatform.iOS))
                {
                    result = await AppleSignInAuthenticator.AuthenticateAsync().ConfigureAwait(false);
                }
                else
                {
                    var authUrl = new Uri(authBaseUrl + provider + authUrlParam);
                    var callbackUrl = new Uri($"{AppInfo.PackageName}://");

                    result = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl).ConfigureAwait(false);
                }

                authToken = result?.AccessToken ?? result?.IdToken ?? result?.Properties["token"];
                if (string.IsNullOrEmpty(authToken))
                {
                    return false;
                }

                var handler = new JwtSecurityTokenHandler();
                var decodedValue = handler.ReadJwtToken(authToken);

                await SecureStorage.SetAsync("oauth_token", authToken).ConfigureAwait(false);
                this.navigationService.SetMainPage(this.mainPage);
                return true;
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                //await DisplayAlertAsync($"Failed: {ex.Message}");
            }
        }
    }
}