using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public partial class MenuButtonFrameControl : Frame
    {
        public MenuButtonFrameControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(Glyph), typeof(string), typeof(ButtonFrameControl), default(string), BindingMode.OneWay);
        public string Glyph
        {
            get => (string)GetValue(GlyphProperty);
            set => SetValue(GlyphProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ButtonFrameControl), default(string), BindingMode.OneWay);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        protected override void OnPropertyChanged(string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == GlyphProperty.PropertyName)
            {
                glyphLabel.Text = Glyph;
            }
            else if (propertyName == TextProperty.PropertyName)
            {
                textLabel.Text = Text;
            }
        }
    }
}