using Wirtualnik.XF.PageModels;
using Xamarin.Forms;

namespace Wirtualnik.XF.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = App.GetPageViewModel<LoginPageModel>();
        }
    }
}