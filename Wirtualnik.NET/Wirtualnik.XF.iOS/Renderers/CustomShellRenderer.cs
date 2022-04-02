using UIKit;
using Wirtualnik.XF.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace Wirtualnik.XF.iOS.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        private UIColor backgroundColor;

        public CustomShellRenderer()
        {
            if (App.Current.RequestedTheme == OSAppTheme.Light)
            {
                if (!App.Current.Resources.TryGetValue("LightBackgroundColorLight", out object resourceColor))
                {
                    return;
                }

                backgroundColor = ((Color)resourceColor).ToUIColor();
            }
            else
            {
                if (!App.Current.Resources.TryGetValue("LightBackgroundColorDark", out object resourceColor))
                {
                    return;
                }

                backgroundColor = ((Color)resourceColor).ToUIColor();
            }

        }

        // https://developer.apple.com/forums/thread/682420
        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            var renderer = base.CreateShellSectionRenderer(shellSection);
            if (renderer is ShellSectionRenderer sectionRenderer)
            {
                var appearance = new UINavigationBarAppearance();
                appearance.ConfigureWithOpaqueBackground();
                appearance.BackgroundColor = backgroundColor;

                sectionRenderer.NavigationBar.ScrollEdgeAppearance =
                    sectionRenderer.NavigationBar.StandardAppearance = appearance;
            }

            return renderer;
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            var renderer = base.CreateShellItemRenderer(item);
            if (renderer is ShellItemRenderer itemRenderer)
            {
                var appearance = new UITabBarAppearance();
                appearance.ConfigureWithOpaqueBackground();
                appearance.ShadowColor = UIColor.Clear;
                appearance.BackgroundColor = backgroundColor;

                itemRenderer.TabBar.StandardAppearance = appearance;

                if (itemRenderer.TabBar.Items != null)
                {
                    foreach (UITabBarItem tabBarItem in itemRenderer.TabBar.Items)
                    {
                        tabBarItem.Title = null;
                        tabBarItem.ImageInsets = new UIEdgeInsets(12, 0, 0, 0);
                    }
                }
            }

            return renderer;
        }
    }
}