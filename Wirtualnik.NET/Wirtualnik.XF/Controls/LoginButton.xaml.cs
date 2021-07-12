using System.Linq;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public partial class LoginButton : Frame
    {
        public LoginButton()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ButtonStyleProperty = BindableProperty.Create(nameof(ButtonStyle), typeof(LoginButtonProvider), typeof(LoginButton), default(LoginButtonProvider), BindingMode.OneWay);
        public LoginButtonProvider ButtonStyle
        {
            get => (LoginButtonProvider)GetValue(ButtonStyleProperty);
            set => SetValue(ButtonStyleProperty, value);
        }

        protected override void OnPropertyChanged(string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ButtonStyleProperty.PropertyName)
            {
                switch (ButtonStyle)
                {
                    case LoginButtonProvider.Apple:
                        this.SetAppThemeColor(Frame.BackgroundColorProperty, Color.White, Color.Black);

                        providerLogoImage.Source = ImageSource.FromFile("apple_logo.xml");

                        providerTextLabel.Text = "Sign in with Apple";
                        break;
                    case LoginButtonProvider.Facebook:
                        this.SetAppThemeColor(Frame.BackgroundColorProperty, Color.FromHex("#1877F2"), Color.White);
                        providerLogoImage.Source = ImageSource.FromFile("facebook_logo.xml");

                        providerTextLabel.Text = "Continue with Facebook";
                        break;
                    case LoginButtonProvider.Google:
                        this.SetAppThemeColor(Frame.BackgroundColorProperty, Color.FromHex("#4285F4"), Color.White);

                        providerLogoImage.Source = ImageSource.FromFile("google_logo.xml");
                        providerLogoImage.SetAppThemeColor(Frame.BackgroundColorProperty, Color.White, Color.Transparent);

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
}