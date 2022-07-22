using Maui.BindableProperty.Generator.Core;
using Xamarin.CommunityToolkit.Effects;

namespace Wirtualnik.Maui.Controls;

public partial class LoginButton : Frame
{
    public LoginButton()
    {
        InitializeComponent();
    }

    [AutoBindable]
    public LoginButtonProvider buttonStyle;

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == ButtonStyleProperty.PropertyName)
        {
            switch (ButtonStyle)
            {
                case LoginButtonProvider.Apple:
                    this.SetAppThemeColor(BackgroundColorProperty, Color.FromArgb("#fff"), Color.FromArgb("#000"));

                    providerLogoImage.Source = ImageSource.FromFile("apple_logo.xml");

                    providerTextLabel.Text = "Sign in with Apple";
                    break;
                case LoginButtonProvider.Facebook:
                    this.SetAppThemeColor(BackgroundColorProperty, Color.FromArgb("#1877F2"), Color.FromArgb("#fff"));
                    providerLogoImage.Source = ImageSource.FromFile("facebook_logo.xml");

                    providerTextLabel.Text = "Continue with Facebook";
                    break;
                case LoginButtonProvider.Google:
                    this.SetAppThemeColor(BackgroundColorProperty, Color.FromArgb("#4285F4"), Color.FromArgb("#fff"));

                    providerLogoImage.Source = ImageSource.FromFile("google_logo.xml");
                    providerLogoImage.SetAppThemeColor(BackgroundColorProperty, Color.FromArgb("#fff"), Color.FromArgb("#00FFFFFF"));

                    var effectToRemove = providerLogoImage.Effects.FirstOrDefault(e => e is IconTintColorEffectRouter);
                    providerLogoImage.Effects.Remove(effectToRemove);

                    providerTextLabel.Text = "Continue with Google";
                    providerTextLabel.FontFamily = "RobotoMedium";
                    break;
                case LoginButtonProvider.None:
                    providerTextLabel.Text = "Sign in with syf";
                    break;
            }
        }
    }
}

public enum LoginButtonProvider
{
    None = -1,
    Apple = 0,
    Facebook = 1,
    Google = 2
}