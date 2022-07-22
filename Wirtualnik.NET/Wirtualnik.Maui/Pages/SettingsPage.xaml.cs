using Wirtualnik.Maui.ViewModels;


namespace Wirtualnik.Maui.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = App.GetPageViewModel<SettingsViewModel>();
        }
    }
}