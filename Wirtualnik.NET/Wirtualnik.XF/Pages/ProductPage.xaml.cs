using Wirtualnik.XF.PageModels;
using Xamarin.Forms;

namespace Wirtualnik.XF.Pages
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();

            BindingContext = App.GetPageViewModel<ProductPageModel>();
        }
    }
}