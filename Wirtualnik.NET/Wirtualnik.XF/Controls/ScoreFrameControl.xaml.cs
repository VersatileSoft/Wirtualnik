using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public partial class ScoreFrameControl : Frame
    {
        // TODO: check single Label with radial gradient background
        public ScoreFrameControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ScoreTitleProperty = BindableProperty.Create(nameof(ScoreTitle), typeof(string), typeof(ScoreFrameControl), default(string), BindingMode.OneWay);
        public string ScoreTitle
        {
            get => (string)GetValue(ScoreTitleProperty);
            set => SetValue(ScoreTitleProperty, value);
        }

        public static readonly BindableProperty ScoreValueProperty = BindableProperty.Create(nameof(ScoreValue), typeof(int), typeof(ScoreFrameControl), default(int), BindingMode.OneWay);
        public int ScoreValue
        {
            get => (int)GetValue(ScoreValueProperty);
            set => SetValue(ScoreValueProperty, value);
        }

        public static readonly BindableProperty ScoreColorProperty = BindableProperty.Create(nameof(ScoreColor), typeof(Color), typeof(ScoreFrameControl), default(Color), BindingMode.OneWay);
        public Color ScoreColor
        {
            get => (Color)GetValue(ScoreColorProperty);
            set => SetValue(ScoreColorProperty, value);
        }

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
                gradientStop.Color = ScoreColor.MultiplyAlpha(0.1);
            }
        }
    }
}