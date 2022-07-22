using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wirtualnik.Maui.Services;

namespace Wirtualnik.Maui.ViewModels.Base;

public partial class BasePageModel : ObservableObject
{
    private readonly INavigationService navigationService;

    private bool isBusy;
    public bool IsBusy
    {
        get => isBusy;
        set => SetProperty(ref isBusy, value);
    }

    public BasePageModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    [ICommand]
    public async Task GoBack()
    {
        await this.navigationService.GoBackAsync().ConfigureAwait(false);
    }
}