using Maui.BindableProperty.Generator.Core;

namespace Wirtualnik.Maui.Controls;

public partial class BaseShellTab : Tab
{
    private readonly FontImageSource fontImageSource = new();

    public BaseShellTab()
    {
        fontImageSource.FontFamily = "la-solid";
        fontImageSource.Size = 32;
        Icon = fontImageSource;
    }

    [AutoBindable]
    public string glyph;

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == GlyphProperty.PropertyName)
        {
            fontImageSource.Glyph = Glyph;
        }
    }
}