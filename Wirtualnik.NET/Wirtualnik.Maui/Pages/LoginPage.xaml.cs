using Wirtualnik.Maui.ViewModels;


namespace Wirtualnik.Maui.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = App.GetPageViewModel<LoginViewModel>();
        }
    }
}