using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public class BaseShellTab : Tab
    {
        private readonly FontImageSource fontImageSource = new();

        public BaseShellTab()
        {
            fontImageSource.FontFamily = "la-solid";
            fontImageSource.Size = 32;
            Icon = fontImageSource;
        }

        public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(Glyph), typeof(string), typeof(BaseShellTab), default(string), BindingMode.OneWay);
        public string Glyph
        {
            get => (string)GetValue(GlyphProperty);
            set => SetValue(GlyphProperty, value);
        }

        protected override void OnPropertyChanged(string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == GlyphProperty.PropertyName)
            {
                fontImageSource.Glyph = Glyph;
            }
        }
    }
}