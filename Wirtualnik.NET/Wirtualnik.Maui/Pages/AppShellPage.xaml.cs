using System;
using Wirtualnik.Maui.Controls;


namespace Wirtualnik.Maui.Pages
{
    public partial class AppShellPage : Shell
    {
        private readonly FontImageSource menuImageSource = new();
        private readonly FontImageSource closeImageSource = new();

        public AppShellPage()
        {
            InitializeComponent();

            LoadIconsFromResources();

            //TODO: Check possibility to make this work with ContentTemplate to enable lazy loading tabs
            foreach (ShellSection shellSection in TabBar.Items)
            {
                var content = shellSection.CurrentItem.Content;
                if (content != null && content is Page page)
                {
                    ToolbarItem toolbarItem = new ToolbarItem
                    {
                        IconImageSource = menuImageSource,
                        Order = ToolbarItemOrder.Primary,
                        Priority = 0
                    };

                    toolbarItem.Clicked += OnItemClicked;

                    page.ToolbarItems.Add(toolbarItem);
                }
            }
        }

        // Some workaround for https://github.com/xamarin/Xamarin.Forms/issues/12700
        private void LoadIconsFromResources()
        {
            if (!Application.Current.Resources.TryGetValue("MenuIcon", out object menuIcon))
            {
                return;
            }

            menuImageSource.FontFamily = "la-solid";
            menuImageSource.Size = 20;
            menuImageSource.Glyph = menuIcon.ToString();

            if (!Application.Current.Resources.TryGetValue("CloseIcon", out object closeIcon))
            {
                return;
            }

            closeImageSource.FontFamily = "la-solid";
            closeImageSource.Size = 20;
            closeImageSource.Glyph = closeIcon.ToString();
        }

        private async void OnItemClicked(object sender, System.EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;

            IPageController? pageController = item.Parent as IPageController;
            if (pageController is null)
            {
                Console.WriteLine($"Something really went wrong in {nameof(AppShellPage)}");
                return;
            }

            var flyoutMenu = pageController.InternalChildren[0] as BaseTabbarPage;
            if (flyoutMenu is null)
            {
                Console.WriteLine($"Can't find flyoutMenu control in {item.Parent}, add 'ControlTemplate=StaticResource ShellTabbedPageTemplate' to make menu toolbar item working.");
                return;
            }

            if (flyoutMenu.OpenMenu)
            {
                item.IconImageSource = menuImageSource;

                await flyoutMenu.CloseSheet();
            }
            else
            {
                item.IconImageSource = closeImageSource;

                await flyoutMenu.OpenSheet();
            }
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
        }
    }
}