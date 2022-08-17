using Maui.BindableProperty.Generator.Core;

namespace Wirtualnik.Maui.Controls;

public partial class BaseToolbarItem : ToolbarItem
{
    private readonly FontImageSource fontImageSource = new();

    public BaseToolbarItem()
    {
        fontImageSource.FontFamily = "la-solid";
        fontImageSource.Size = 20;
        IconImageSource = fontImageSource;
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