using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using AndroidX.Core.View;
using Microsoft.Extensions.DependencyInjection;
using Sentry;
using Wirtualnik.XF.Droid.Services;
using Wirtualnik.XF.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wirtualnik.XF.Droid
{
    [Activity(MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SentryXamarin.Init(options =>
            {
                options.Dsn = "https://6d41b18b43a74862b64c0239985b9ee8@o866902.ingest.sentry.io/5823541";
#if DEBUG
                options.Debug = true;
                options.TracesSampleRate = 0;
#endif
#if RELEASE
                options.TracesSampleRate = 1.0;
#endif
                options.AddXamarinFormsIntegration();
            });

            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            Android.Glide.Forms.Init(this, debug: false);
            FormsMaterial.Init(this, savedInstanceState);
            UserDialogs.Init(this);

            LoadApplication(new App(AddPlatformServices));

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
            var barsColor = currentTheme == OSAppTheme.Light ? ColorConverters.FromHex("#f9f9f9").ToPlatformColor() : ColorConverters.FromHex("#222222").ToPlatformColor();
            var backgroundColor = currentTheme == OSAppTheme.Light ? ColorConverters.FromHex("#f3f3f3").ToPlatformColor() : ColorConverters.FromHex("#191919").ToPlatformColor();
            //var window = Platform.CurrentActivity.Window;

            if (this.Window is null)
            {
                return;
            }

            this.Window.SetBackgroundDrawable(new ColorDrawable(backgroundColor)); //this.ApplicationContext.GetDrawable(Resource.Drawable.splash_screen));
            this.Window.SetStatusBarColor(barsColor);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                this.Window.SetNavigationBarColor(barsColor);
            }

            using var controller = WindowCompat.GetInsetsController(this.Window, this.Window.DecorView.RootView);
            controller.AppearanceLightStatusBars = currentTheme == OSAppTheme.Light;
            controller.AppearanceLightNavigationBars = currentTheme == OSAppTheme.Light;
        }

        private static void AddPlatformServices(IServiceCollection services)
        {
            services.AddSingleton<IEnviroment, Enviroment>();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

