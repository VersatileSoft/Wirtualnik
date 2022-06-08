using Xamarin.Forms;

namespace Wirtualnik.XF.Controls
{
    public class WirtualnikTitleView : Label
    {
        public WirtualnikTitleView()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            if (!Application.Current.Resources.TryGetValue("RedAccentColorLight", out object accentColor))
            {
                return;
            }

            Margin = new Thickness(0, 8, 0, 0);
            VerticalTextAlignment = TextAlignment.Center;
            FontFamily = "PoppinsBold";
            FontSize = 22;
            Text = "WIRTUALNIK";

            //TODO: There is possibility to need to change this color based on app theme - then use AppThemeBinding
            TextColor = (Color)accentColor;
        }

    }
}