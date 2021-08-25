using Wirtualnik.XF.PageModels.Base;
using Wirtualnik.XF.Services;

namespace Wirtualnik.XF.PageModels
{
    public class ProductPageModel : BasePageModel
    {
        public ProductPageModel(INavigationService navigationService) : base(navigationService)
        {
            IsBusy = true;
        }
    }
}