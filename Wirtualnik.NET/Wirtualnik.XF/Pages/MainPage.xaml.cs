using System;
using Wirtualnik.XF.PageModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Wirtualnik.XF.Pages
{
    public partial class MainPage : ContentPage
    {
        private bool isMenuOpened;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = App.GetPageViewModel<MainPageModel>();
        }

        private void tabView_SelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            // https://github.com/xamarin/Xamarin.Forms/issues/8718
            contentCarouselView.ScrollTo(tabView.SelectedIndex, animate: true);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            CloseMenuAnimations();
        }

        private void menuButton_Clicked(object sender, EventArgs e)
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
            menuButton.Text = closeIcon.ToString();

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

        protected override bool OnBackButtonPressed()
        {
            if (isMenuOpened)
            {
                CloseMenuAnimations();
                return true;
            }

            return base.OnBackButtonPressed();
        }
    }
}