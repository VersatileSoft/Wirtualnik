using Android.Content;
using Android.OS;
using Android.Views;
using Google.Android.Material.AppBar;
using Google.Android.Material.BottomNavigation;
using Wirtualnik.XF.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using LP = Android.Views.ViewGroup.LayoutParams;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace Wirtualnik.XF.Droid.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new CustomShellItemRenderer(this);
        }

        //protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
        //{
        //    base.CreateToolbarAppearanceTracker();
        //    return new CustomShellToolbarAppearanceTracker(this);
        //}

        //protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        //{
        //    base.CreateBottomNavViewAppearanceTracker(shellItem);
        //    //return new CustomShellBottomNavViewAppearanceTracker(this, shellItem);
        //}
    }

    public class CustomShellItemRenderer : ShellItemRenderer
    {
        private BottomNavigationView _bottomView;

        public CustomShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var outerlayout = base.OnCreateView(inflater, container, savedInstanceState);

            _bottomView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);
            _bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityUnlabeled;

            return outerlayout;
        }
    }

    public class CustomShellToolbarAppearanceTracker : ShellToolbarAppearanceTracker
    {
        public CustomShellToolbarAppearanceTracker(IShellContext shellContext) : base(shellContext)
        {
        }

        public override void SetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
        {
            toolbar.LayoutParameters = new AppBarLayout.LayoutParams(LP.MatchParent, LP.WrapContent)
            {
                ScrollFlags = AppBarLayout.LayoutParams.ScrollFlagScroll |
                AppBarLayout.LayoutParams.ScrollFlagEnterAlways
            };
            base.SetAppearance(toolbar, toolbarTracker, appearance);
        }
    }

    public class CustomShellBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
    {
        public CustomShellBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem) : base(shellContext, shellItem)
        {
        }

        public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            bottomView.LayoutParameters = new AppBarLayout.LayoutParams(LP.MatchParent, LP.WrapContent)
            {
                ScrollFlags = AppBarLayout.LayoutParams.ScrollFlagScroll |
                AppBarLayout.LayoutParams.ScrollFlagEnterAlways
            };
            base.SetAppearance(bottomView, appearance);
        }
    }
}