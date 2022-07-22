using Wirtualnik.Maui.ViewModels.Base;
using Wirtualnik.Maui.Services;

namespace Wirtualnik.Maui.ViewModels;

public class ProductViewModel : BasePageModel
{
    public ProductViewModel(INavigationService navigationService) : base(navigationService)
    {
        IsBusy = true;
    }
}