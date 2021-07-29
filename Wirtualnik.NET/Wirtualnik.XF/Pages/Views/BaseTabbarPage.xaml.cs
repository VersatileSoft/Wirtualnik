using TinyMvvm;
using TinyMvvm.Forms;
using Xamarin.Forms;

namespace Wirtualnik.XF.Views
{
    public partial class BaseTabbarPage
    {
        private bool isMenuOpened;

        public BaseTabbarPage()
        {
            InitializeComponent();
        }

        private void BaseToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (isMenuOpened)
            {
                CloseMenuAnimations();
            }
            else
            {
                OpenMenuAnimations();
            }
        }

        private void OpenMenuAnimations()
        {
            if (!Application.Current.Resources.TryGetValue("CloseIcon", out object closeIcon))
            {
                return;
            }
            menuButton.Glyph = closeIcon.ToString();

            menuBackgroundGrid.FadeTo(1, 200, Easing.CubicOut);
            menuPancakeView.TranslateTo(0, 0, 200, Easing.CubicOut);

            //actionBar.Border = new Xamarin.Forms.PancakeView.Border() { Color = Color.Gray, Thickness = 1 };
            //actionBar.Shadow = null;

            menuBackgroundGrid.InputTransparent = false;
            isMenuOpened = true;
        }

        private void CloseMenuAnimations()
        {
            if (!Application.Current.Resources.TryGetValue("MenuIcon", out object menuIcon))
            {
                return;
            }
            menuButton.Text = menuIcon.ToString();

            menuBackgroundGrid.FadeTo(0, 200, Easing.CubicIn);
            menuPancakeView.TranslateTo(0, -250, 200, Easing.CubicIn);

            //actionBar.Shadow = new Xamarin.Forms.PancakeView.DropShadow() { Color = Color.Black };
            //actionBar.Border = null;

            menuBackgroundGrid.InputTransparent = true;
            isMenuOpened = false;
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    if (isMenuOpened)
        //    {
        //        CloseMenuAnimations();
        //        return true;
        //    }

        //    return base.OnBackButtonPressed();
        //}
    }
}