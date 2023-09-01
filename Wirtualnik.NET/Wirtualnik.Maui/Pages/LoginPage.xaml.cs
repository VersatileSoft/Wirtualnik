using Wirtualnik.Maui.ViewModels;


namespace Wirtualnik.Maui.Pages
{
    public partial class LoginPage : TinyView
    {
        public LoginPage(LoginViewModel loginViewModel)
        {
            InitializeComponent();

            BindingContext = loginViewModel;
        }
    }
}