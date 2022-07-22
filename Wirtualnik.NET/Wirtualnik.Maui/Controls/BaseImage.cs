using Maui.BindableProperty.Generator.Core;

namespace Wirtualnik.Maui.Controls;

public partial class BaseImage : Image
{
    private const string BaseUrl = "https://api.zlcn.pro/";

    [AutoBindable]
    public string sourceWithHost;

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == SourceWithHostProperty.PropertyName)
        {
            if (string.IsNullOrEmpty(SourceWithHost))
            {
                return;
            }

            this.Source = ImageSource.FromUri(new Uri(BaseUrl + SourceWithHost));
        }
    }
}