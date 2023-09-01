using Wirtualnik.Maui.ViewModels;


namespace Wirtualnik.Maui.Pages
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage(SearchViewModel searchViewModel)
        {
            InitializeComponent();

            BindingContext = searchViewModel;
        }
    }
}