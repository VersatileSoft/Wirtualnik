using Wirtualnik.Maui.ViewModels;


namespace Wirtualnik.Maui.Pages
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();

            BindingContext = App.GetPageViewModel<ProductViewModel>();
        }
    }
}