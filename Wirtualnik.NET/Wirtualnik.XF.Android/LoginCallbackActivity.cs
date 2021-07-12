﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Wirtualnik.XF.Droid
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
    Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
    DataScheme = "xamarinessentials")] //"com.versatilesoftware.wirtualnik")]
    public class LoginCallbackActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {
    }
}