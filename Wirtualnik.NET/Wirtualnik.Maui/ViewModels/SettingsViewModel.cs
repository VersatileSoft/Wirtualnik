using Wirtualnik.Maui.ViewModels.Base;
using Wirtualnik.Maui.Services;

namespace Wirtualnik.Maui.ViewModels;

public class SettingsViewModel : BasePageModel
{
    //private readonly IEnviroment enviroment;

    public SettingsViewModel(INavigationService navigationService) : base(navigationService)
    {
        //this.enviroment = enviroment;
    }

    public void SetTheme()
    {
        switch (Theme)
        {
            //default
            case 0:
                App.Current.UserAppTheme = AppTheme.Unspecified;
                break;
            //light
            case 1:
                App.Current.UserAppTheme = AppTheme.Light;
                break;
            //dark
            case 2:
                App.Current.UserAppTheme = AppTheme.Dark;
                break;
        }

        if (App.Current.RequestedTheme == AppTheme.Dark)
        {
            //this.enviroment.SetSystemBarsColor(System.Drawing.Color.Black, false);
        }
        else
        {
            //this.enviroment.SetSystemBarsColor(System.Drawing.Color.White, true);
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