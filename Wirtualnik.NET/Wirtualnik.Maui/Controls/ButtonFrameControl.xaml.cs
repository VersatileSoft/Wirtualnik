using Maui.BindableProperty.Generator.Core;

namespace Wirtualnik.Maui.Controls
{
    public partial class ButtonFrameControl : Frame
    {
        public ButtonFrameControl()
        {
            InitializeComponent();

            //this.CornerRadius = (float)(Width / 2);
        }

        [AutoBindable]
        public string glyph;

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