using Wirtualnik.Maui.ViewModels.Base;
using Wirtualnik.Maui.Services;

namespace Wirtualnik.Maui.ViewModels;

public class SearchViewModel : BasePageModel
{
    public SearchViewModel(INavigationService navigationService) : base(navigationService)
    {
        IsBusy = true;
    }
}