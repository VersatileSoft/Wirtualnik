using Maui.BindableProperty.Generator.Core;

namespace Wirtualnik.Maui.Controls;

public partial class ScoreFrameControl : ContentView
{
    public ScoreFrameControl()
    {
        InitializeComponent();
    }

    [AutoBindable]
    public string scoreTitle;

    [AutoBindable]
    public int scoreValue;

    [AutoBindable]
    public Color scoreColor;

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == ScoreTitleProperty.PropertyName)
        {
            spanTitle.Text = ScoreTitle;
        }
        else if (propertyName == ScoreValueProperty.PropertyName)
        {
            spanScore.Text = ScoreValue.ToString();
        }
        else if (propertyName == ScoreColorProperty.PropertyName)
        {
            scoreLabel.TextColor = ScoreColor;
            gradientStop.Color = ScoreColor.MultiplyAlpha(0.1f);
        }
    }
}