using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Core.View;
using Google.Android.Material.AppBar;
using Google.Android.Material.BottomNavigation;
using Java.Lang;
using static System.Math;

namespace Wirtualnik.XF.Droid.Extensions
{
    [Register("com.versatilesoftware.wirtualnik.BottomNavigationViewBehavior")]
    public class BottomNavigationViewBehavior : CoordinatorLayout.Behavior
    {
        public BottomNavigationViewBehavior(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public override bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Object child, View directTargetChild, View target, int axes, int type)
        {
            return axes == ViewCompat.ScrollAxisVertical;
        }

        public override void OnNestedPreScroll(CoordinatorLayout coordinatorLayout, Object child, View target, int dx, int dy, int[] consumed, int type)
        {
            base.OnNestedPreScroll(coordinatorLayout, child, target, dx, dy, consumed, type);

            if (child is BottomNavigationView navigationView)
            {
                navigationView.TranslationY = Max(0f, Min((float)navigationView.Height, navigationView.TranslationY + dy));
            }
            else if (child is AppBarLayout barLayout)
            {
                barLayout.TranslationY = Max(0f, Min((float)barLayout.Height, barLayout.TranslationY + dy)) * (-1);
            }
            //BottomNavigationView? childView = child.JavaCast<BottomNavigationView>();

            //childView.TranslationY = Max(0f, Min((float)childView.Height, childView.TranslationY + dy));
        }
    }
}