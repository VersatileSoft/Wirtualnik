using Android.App;
using Android.Content;
using Android.Content.PM;

namespace Wirtualnik.Maui;

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(new[] { Android.Content.Intent.ActionView },
Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
DataScheme = "com.versatilesoftware.wirtualnik")]
public class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity
{
}