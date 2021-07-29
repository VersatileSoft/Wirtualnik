using Wirtualnik.XF.PageModels.Base;
using Wirtualnik.XF.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wirtualnik.XF.PageModels
{
    public class SettingsPageModel : BasePageModel
    {
        private readonly IEnviroment enviroment;

        public SettingsPageModel(IEnviroment enviroment, INavigationService navigationService) : base(navigationService)
        {
            this.enviroment = enviroment;
        }

        public void SetTheme()
        {
            switch (Theme)
            {
                //default
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                //light
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }

            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                this.enviroment.SetSystemBarsColor(System.Drawing.Color.Black, false);
            }
            else
            {
                this.enviroment.SetSystemBarsColor(System.Drawing.Color.White, true);
            }
        }

        // 0 = default, 1 = light, 2 = dark
        private const int theme = 0;
        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), theme);
            set => Preferences.Set(nameof(Theme), value);
        }
    }
}
