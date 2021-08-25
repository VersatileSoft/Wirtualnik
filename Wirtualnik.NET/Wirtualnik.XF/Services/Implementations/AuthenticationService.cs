using System;
using System.Threading.Tasks;
using Wirtualnik.XF.Pages;
using Xamarin.Essentials;

namespace Wirtualnik.XF.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string authenticationUrl = "https://zlcn.pro/auth/login/";

        private readonly INavigationService navigationService;

        public AuthenticationService(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public async Task<bool> SignInAsync(string? scheme)
        {
            var authToken = string.Empty;
            WebAuthenticatorResult? result = null;

            try
            {
                if (string.IsNullOrEmpty(scheme) || (scheme.Equals("Apple") && DeviceInfo.Platform == DevicePlatform.iOS))
                {
                    result = await AppleSignInAuthenticator.AuthenticateAsync().ConfigureAwait(false);
                }
                else
                {
                    var authUrl = new Uri(authenticationUrl + scheme);
                    var callbackUrl = new Uri($"{AppInfo.PackageName}://");

                    result = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl).ConfigureAwait(false);
                }

                authToken = result?.AccessToken ?? result?.IdToken ?? result?.Properties["token"];
                if (string.IsNullOrEmpty(authToken))
                {
                    return false;
                }

                await SecureStorage.SetAsync("oauth_token", authToken).ConfigureAwait(false);
                this.navigationService.SetMainPage<MainPage>();
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