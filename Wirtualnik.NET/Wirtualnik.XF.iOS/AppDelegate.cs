using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;
using Xamarin.Forms;

namespace Wirtualnik.XF.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Forms.Init();
            FormsMaterial.Init();
            Xamarin.Forms.Nuke.FormsHandler.Init(debug: true);
            LoadApplication(new App(new IOSInitializer()));

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }

    public class IOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
