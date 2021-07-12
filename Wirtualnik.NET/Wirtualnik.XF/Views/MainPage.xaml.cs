using DryIoc;
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

        private SafeObservableCollection<View> pageList = new();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = App.Container.Resolve(typeof(MainPageViewModel));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            pageList.Add(new CustomLazyView<ProductListPage, ProductListPageViewModel>());
            pageList.Add(new CustomLazyView<ProductListPage, ProductListPageViewModel>());
            pageList.Add(new CustomLazyView<ProductListPage, ProductListPageViewModel>());
            pageList.Add(new CustomLazyView<ProductListPage, ProductListPageViewModel>());

            pageList.Add(new CustomLazyView<ProductListPage, ProductListPageViewModel>());

            contentCarouselView.ItemsSource = pageList;
        }

        private void tabView_SelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            contentCarouselView.ScrollTo(tabView.SelectedIndex, animate: true);

            //await contentCarouselView.CurrentItem.LoadViewAsync().ConfigureAwait(false);
        }

        private async void contentCarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var view = (BaseLazyView)e.CurrentItem;

            if (view.IsLoaded)
            {
                return;
            }

            await view.LoadViewAsync();
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
            menuPancakeView.TranslateTo(0, -300, 200, Easing.CubicIn);

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