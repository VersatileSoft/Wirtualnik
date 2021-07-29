using Xamarin.Forms;

namespace Wirtualnik.XF.Controls.Settings
{
    public partial class SettingCell : Grid
    {
        public SettingCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(SettingCell), default(string), BindingMode.OneWay);
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(SettingCell), default(string), BindingMode.OneWay);
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly BindableProperty IsTopSeparatorVisibleProperty = BindableProperty.Create(nameof(IsTopSeparatorVisible), typeof(bool), typeof(SettingCell), true, BindingMode.OneWay);
        public bool IsTopSeparatorVisible
        {
            get => (bool)GetValue(IsTopSeparatorVisibleProperty);
            set => SetValue(IsTopSeparatorVisibleProperty, value);
        }

        protected override void OnPropertyChanged(string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TitleProperty.PropertyName)
            {
                titleLabel.Text = Title;
            }
            else if (propertyName == DescriptionProperty.PropertyName)
            {
                descriptionLabel.Text = Description;
            }
            else if (propertyName == IsTopSeparatorVisibleProperty.PropertyName)
            {
                separatorBoxView.IsVisible = IsTopSeparatorVisible;
            }
        }
    }
}