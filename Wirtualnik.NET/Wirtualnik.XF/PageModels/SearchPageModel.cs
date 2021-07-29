using Wirtualnik.XF.PageModels.Base;
using Wirtualnik.XF.Services;

namespace Wirtualnik.XF.PageModels
{
    public class SearchPageModel : BasePageModel
    {
        public SearchPageModel(INavigationService navigationService) : base(navigationService)
        {
            IsBusy = true;
        }
    }
}
