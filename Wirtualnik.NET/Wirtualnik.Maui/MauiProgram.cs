using System.Reflection;
using Wirtualnik.Shared.ApiClient;
//using Xamarin.CommunityToolkit.Android.Effects;
//using Xamarin.CommunityToolkit.Effects;

namespace Wirtualnik.Maui;

public static partial class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        UseAutoreg(builder.Services);

        var currentAssembly = Assembly.GetExecutingAssembly();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseTinyMvvm()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("icomoon.ttf", "FontIcons");
                fonts.AddFont("la-solid-900.ttf", "la-solid");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSemiBold");
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-Light.ttf", "PoppinsLight");
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
            })
            //.ConfigureEffects(effects =>
            //{
            //    effects.Add<StatusBarEffect, PlatformStatusBarEffect>();
            //    effects.Add<TouchEffect, PlatformTouchEffect>();
            //    //effects.Add<CornerRadiusEffect, PlatformCornerRadiusEffect>();
            //})
            .Services
            .RegisterClients();

        var app = builder.Build();

        return app;
    }

    static partial void UseAutoreg(IServiceCollection services);
}