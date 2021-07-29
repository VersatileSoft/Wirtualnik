using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;
using Wirtualnik.XF.Services;
using Xamarin.Essentials;

namespace Wirtualnik.XF.Droid.Services
{
    public class Enviroment : IEnviroment
    {
        private readonly Window? Window = Platform.CurrentActivity.Window;

        public Enviroment()
        {
            //var barsColor = CurrentTheme == OSAppTheme.Light ? ColorConverters.FromHex("#f9f9f9").ToPlatformColor() : ColorConverters.FromHex("#222222").ToPlatformColor();
            //var backgroundColor = CurrentTheme == OSAppTheme.Light ? ColorConverters.FromHex("#f3f3f3").ToPlatformColor() : ColorConverters.FromHex("#191919").ToPlatformColor();
        }

        public void SetSystemBarsColor(System.Drawing.Color backgroundColor, bool isThisColorLight)
        {
            if (Window is null)
            {
                return;
            }

            var platformColor = backgroundColor.ToPlatformColor();

            Window.SetStatusBarColor(platformColor);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                Window.SetNavigationBarColor(platformColor);
            }

            using var controller = WindowCompat.GetInsetsController(Window, Window.DecorView.RootView);
            controller.AppearanceLightStatusBars = isThisColorLight;
            controller.AppearanceLightNavigationBars = isThisColorLight;
        }

        public void SetBackground(bool setSplashAsBackground, System.Drawing.Color? backgroundColor)
        {
            if (Window is null || !backgroundColor.HasValue || !setSplashAsBackground)
            {
                return;
            }

            if (setSplashAsBackground)
            {
                Window.SetBackgroundDrawable(Platform.CurrentActivity.GetDrawable(Resource.Drawable.splash_screen));
                return;
            }

            Window.SetBackgroundDrawable(new ColorDrawable(backgroundColor.Value.ToPlatformColor()));
        }
    }
}