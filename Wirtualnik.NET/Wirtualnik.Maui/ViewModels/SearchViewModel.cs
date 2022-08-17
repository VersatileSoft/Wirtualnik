using Wirtualnik.Maui.Services;
using Wirtualnik.Maui.ViewModels.Base;

namespace Wirtualnik.Maui.ViewModels;

public class SearchViewModel : BasePageModel
{
    public SearchViewModel(INavigationService navigationService) : base(navigationService)
    {
        IsBusy = true;
    }
}