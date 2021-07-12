using DryIoc;
using Wirtualnik.XF.ViewModels;
using Xamarin.Forms;

namespace Wirtualnik.XF.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = App.Container.Resolve(typeof(LoginPageViewModel));
        }
    }
}