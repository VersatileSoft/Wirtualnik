using Wirtualnik.Maui.Services;

namespace Wirtualnik.Maui.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthenticationService authenticationService;

    public LoginViewModel(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    [RelayCommand]
    public async Task SignIn(string scheme)
    {
        await this.authenticationService.SignInAsync(scheme).ConfigureAwait(false);
    }
}