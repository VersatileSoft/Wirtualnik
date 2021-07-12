using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public partial class ButtonFrameControl : Frame
    {
        public ButtonFrameControl()
        {
            InitializeComponent();

            //this.CornerRadius = (float)(Width / 2);
        }

        public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(Glyph), typeof(string), typeof(ButtonFrameControl), default(string), BindingMode.OneWay);
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
                iconLabel.Text = Glyph;
            }
        }
    }
}