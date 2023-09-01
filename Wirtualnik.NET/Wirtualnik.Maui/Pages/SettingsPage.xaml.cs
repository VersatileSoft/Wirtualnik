using Wirtualnik.Maui.ViewModels;


namespace Wirtualnik.Maui.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(SettingsViewModel settingsViewModel)
        {
            InitializeComponent();

            BindingContext = settingsViewModel;
        }
    }
}