using Wirtualnik.XF.PageModels;
using Xamarin.Forms;

namespace Wirtualnik.XF.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = App.GetPageViewModel<SettingsPageModel>();
        }
    }
}