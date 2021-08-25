using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public class CheckBoxImageButton : ImageButton
    {
        private readonly FontImageSource fontImageSource = new();

        public CheckBoxImageButton()
        {
            Application.Current.Resources.TryGetValue("MenuIcon", out object uncheckIcon);

            fontImageSource.FontFamily = "la-solid";
            fontImageSource.Glyph = uncheckIcon.ToString();
            Source = fontImageSource;
        }

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(CheckBoxImageButton), default(bool), BindingMode.TwoWay);
        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public static readonly BindableProperty ColorGlyphProperty = BindableProperty.Create(nameof(ColorGlyph), typeof(Color), typeof(CheckBoxImageButton), default(Color), BindingMode.OneWay);
        public Color ColorGlyph
        {
            get => (Color)GetValue(ColorGlyphProperty);
            set => SetValue(ColorGlyphProperty, value);
        }

        public static readonly BindableProperty IsCheckedGlyphProperty = BindableProperty.Create(nameof(IsCheckedGlyph), typeof(string), typeof(CheckBoxImageButton), default(string), BindingMode.OneWay);
        public string IsCheckedGlyph
        {
            get => (string)GetValue(IsCheckedGlyphProperty);
            set => SetValue(IsCheckedGlyphProperty, value);
        }

        public static readonly BindableProperty NotCheckedGlyphProperty = BindableProperty.Create(nameof(NotCheckedGlyph), typeof(string), typeof(CheckBoxImageButton), default(string), BindingMode.OneWay);
        public string NotCheckedGlyph
        {
            get => (string)GetValue(NotCheckedGlyphProperty);
            set => SetValue(NotCheckedGlyphProperty, value);
        }

        protected override void OnPropertyChanged(string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsCheckedProperty.PropertyName)
            {
                fontImageSource.Glyph = IsChecked ? IsCheckedGlyph : NotCheckedGlyph;
            }
            else if (propertyName == ColorGlyphProperty.PropertyName)
            {
                fontImageSource.Color = ColorGlyph;
            }
        }
    }
}