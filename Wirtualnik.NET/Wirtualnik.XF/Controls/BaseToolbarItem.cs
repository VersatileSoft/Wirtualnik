using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public class BaseToolbarItem : ToolbarItem
    {
        private readonly FontImageSource fontImageSource = new();

        public BaseToolbarItem()
        {
            fontImageSource.FontFamily = "la-solid";
            fontImageSource.Size = 20;
            IconImageSource = fontImageSource;
        }

        public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(Glyph), typeof(string), typeof(BaseToolbarItem), default(string), BindingMode.OneWay);
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