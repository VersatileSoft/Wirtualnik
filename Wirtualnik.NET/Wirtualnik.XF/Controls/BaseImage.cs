using System;
using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public class BaseImage : Image
    {
        private const string BaseUrl = "https://api.zlcn.pro/";

        public static readonly BindableProperty SourceWithHostProperty = BindableProperty.Create(nameof(SourceWithHost), typeof(string), typeof(BaseImage), default(string), BindingMode.OneWay);
        public string SourceWithHost
        {
            get => (string)GetValue(SourceWithHostProperty);
            set => SetValue(SourceWithHostProperty, value);
        }

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
}