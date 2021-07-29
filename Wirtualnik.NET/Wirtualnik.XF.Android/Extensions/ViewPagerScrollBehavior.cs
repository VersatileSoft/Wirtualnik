using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.CoordinatorLayout.Widget;
using Google.Android.Material.AppBar;
using Google.Android.Material.BottomNavigation;
using Java.Lang;

namespace Wirtualnik.XF.Droid.Extensions
{
    [Register("com.versatilesoftware.wirtualnik.ViewPagerScrollBehavior")]
    public class ViewPagerScrollBehavior : AppBarLayout.ScrollingViewBehavior
    {
        // We add a bottom margin to avoid the bottom navigation bar
        private int bottomMargin;

        public ViewPagerScrollBehavior(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public override bool LayoutDependsOn(CoordinatorLayout parent, Object child, View dependency)
        {
            return base.LayoutDependsOn(parent, child, dependency) || dependency is BottomNavigationView;
        }

        public override bool OnDependentViewChanged(CoordinatorLayout parent, Object child, View dependency)
        {
            bool result = base.OnDependentViewChanged(parent, child, dependency);

            if (dependency is BottomNavigationView && child is View childView && dependency.Height != bottomMargin)
            {
                bottomMargin = dependency.Height;
                var layout = childView.LayoutParameters as CoordinatorLayout.LayoutParams;
                layout.BottomMargin = bottomMargin;
                //layout.RequestLayout();
                return true;
            }

            return false;
        }

        //public override bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Object child, View directTargetChild, View target, int axes, int type)
        //{
        //    return axes == ViewCompat.ScrollAxisVertical;
        //}

        //public override void OnNestedPreScroll(CoordinatorLayout coordinatorLayout, Object child, View target, int dx, int dy, int[] consumed, int type)
        //{
        //    base.OnNestedPreScroll(coordinatorLayout, child, target, dx, dy, consumed, type);

        //    if (child is BottomNavigationView navigationView)
        //    {
        //        navigationView.TranslationY = Max(0f, Min((float)navigationView.Height, navigationView.TranslationY + dy));
        //    }
        //    else if (child is AppBarLayout barLayout)
        //    {
        //        barLayout.TranslationY = Max(0f, Min((float)barLayout.Height, barLayout.TranslationY + dy)) * (-1);
        //    }
        //}
    }
}