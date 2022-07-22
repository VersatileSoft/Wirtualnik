using Maui.BindableProperty.Generator.Core;

namespace Wirtualnik.Maui.Controls;

public partial class MenuButtonFrameControl : Frame
{
    public MenuButtonFrameControl()
    {
        InitializeComponent();
    }

    [AutoBindable]
    public string glyph;

    [AutoBindable]
    public string text;

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