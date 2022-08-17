using Wirtualnik.Maui.Services;
using Wirtualnik.Maui.ViewModels.Base;

namespace Wirtualnik.Maui.ViewModels;

public class ProductViewModel : BasePageModel
{
    public ProductViewModel(INavigationService navigationService) : base(navigationService)
    {
        IsBusy = true;
    }
}