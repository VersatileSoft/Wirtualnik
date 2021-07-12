using Wirtualnik.XF.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.XF.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IAuthenticationService authenticationService;

        public AsyncCommand<string> SignInCommand { get; set; }

        public LoginPageViewModel(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;

            SignInCommand = new AsyncCommand<string>(async (scheme) =>
                await this.authenticationService.SignInAsync(scheme).ConfigureAwait(false), allowsMultipleExecutions: false);
        }
    }
}
