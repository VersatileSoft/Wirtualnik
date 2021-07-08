﻿using Foundation;
using Sentry;
using UIKit;
using Xamarin.Forms;

namespace Wirtualnik.XF.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
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

            Forms.Init();
            FormsMaterial.Init();
            Xamarin.Forms.Nuke.FormsHandler.Init(debug: true);
            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
