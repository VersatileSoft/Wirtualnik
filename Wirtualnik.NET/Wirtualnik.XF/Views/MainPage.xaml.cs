using System;
using Wirtualnik.Extensions;
using Wirtualnik.XF.Controls;
using Wirtualnik.XF.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Wirtualnik.XF.Views
{
    public partial class MainPage : ContentPage
    {
        private bool isMenuOpened;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var pageList = new SafeObservableCollection<View>();

            pageList.Add(new LazyView<SettingsPage>());
            pageList.Add(new LazyView<ProductPage>());
            pageList.Add(new LazyView<ProductPage>());
            pageList.Add(new LazyView<ProductPage>());

            pageList.Add(new CustomLazyView<ProductListPage>(typeof(ProductListPageViewModel)));

            contentCarouselView.ItemsSource = pageList;
        }

        private void tabView_SelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            contentCarouselView.ScrollTo(tabView.SelectedIndex);
        }

        private async void contentCarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var view = (BaseLazyView)contentCarouselView.CurrentItem;

            if (view.IsLoaded)
            {
                return;
            }

            await view.LoadViewAsync().ConfigureAwait(false);
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

            menuBackgroundGrid.FadeTo(1, 300, Easing.CubicOut);
            menuPancakeView.TranslateTo(0, 0, 300, Easing.CubicOut);

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

            menuBackgroundGrid.FadeTo(0, 300, Easing.CubicIn);
            menuPancakeView.TranslateTo(0, -300, 300, Easing.CubicIn);

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