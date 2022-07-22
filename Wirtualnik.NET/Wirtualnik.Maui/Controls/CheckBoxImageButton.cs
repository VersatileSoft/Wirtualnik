using Maui.BindableProperty.Generator.Core;

namespace Wirtualnik.Maui.Controls;

public partial class CheckBoxImageButton : ImageButton
{
    private readonly FontImageSource fontImageSource = new();

    public CheckBoxImageButton()
    {
        Application.Current.Resources.TryGetValue("MenuIcon", out object uncheckIcon);

        fontImageSource.FontFamily = "la-solid";
        fontImageSource.Glyph = uncheckIcon.ToString();
        Source = fontImageSource;
    }

    [AutoBindable]
    public bool isChecked;

    [AutoBindable]
    public Color colorGlyph;

    [AutoBindable]
    public string isCheckedGlyph;

    [AutoBindable]
    public string notCheckedGlyph;

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