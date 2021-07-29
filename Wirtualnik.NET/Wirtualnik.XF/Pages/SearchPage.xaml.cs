using Wirtualnik.XF.PageModels;
using Xamarin.Forms;

namespace Wirtualnik.XF.Pages
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();

            BindingContext = App.GetPageViewModel<SearchPageModel>();
        }
    }
}