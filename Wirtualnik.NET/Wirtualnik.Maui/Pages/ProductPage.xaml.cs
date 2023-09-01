using Wirtualnik.Maui.ViewModels;


namespace Wirtualnik.Maui.Pages
{
    public partial class ProductPage : TinyView
    {
        public ProductPage(ProductViewModel productViewModel)
        {
            InitializeComponent();

            BindingContext = productViewModel;
        }
    }
}