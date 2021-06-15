using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wirtualnik.XF.Droid
{
    [Activity(MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private OSAppTheme lastTheme;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Forms.Init(this, savedInstanceState);

            LoadApplication(new App(new AndroidInitializer()));

            SetTheme(Resource.Style.MainTheme);
        }

        protected override void OnResume()
        {
            base.OnResume();

            SetStatusBarColor();
        }

        public void SetStatusBarColor()
        {
            var currentTheme = Xamarin.Forms.Application.Current.RequestedTheme;

            if (lastTheme == currentTheme)
            {
                return;
            }

            var color = currentTheme == OSAppTheme.Light ? Android.Graphics.Color.ParseColor("#e0e0e0") : Android.Graphics.Color.ParseColor("#303030");

            var window = Platform.CurrentActivity.Window;

            if (window is null)
            {
                return;
            }

            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.SetStatusBarColor(color);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                window.SetNavigationBarColor(color);
            }

            const StatusBarVisibility statusBarVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar
                | (StatusBarVisibility)SystemUiFlags.LightNavigationBar;
            //window.DecorView.SystemUiVisibility = currentTheme == OSAppTheme.Light ? statusBarVisibility : 0;

            var lol = currentTheme == OSAppTheme.Light ? (int)statusBarVisibility : 0;

            window.DecorView.WindowInsetsController?.SetSystemBarsAppearance(lol, (int)SystemUiFlags.LightStatusBar);

            lastTheme = currentTheme;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

