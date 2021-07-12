using Android.Content;
using System;
using Wirtualnik.XF.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TabViewCarouselView), typeof(Wirtualnik.XF.Droid.Renderers.TabViewCarouselViewRenderer))]
namespace Wirtualnik.XF.Droid.Renderers
{
    public class TabViewCarouselViewRenderer : CarouselViewRenderer
    {
        public TabViewCarouselViewRenderer(Context context) : base(context) { }

        protected override void UpdateAdapter()
        {
            base.UpdateAdapter();

            ItemsViewAdapter = new CustomItemsViewAdapter<ItemsView, IItemsViewSource>(Carousel,
                (__, _) => new SizedItemContentView(Context, GetItemWidth, GetItemHeight));
        }

        // Copied from the source Xamarin.Forms because of the accessibility levels
        private int GetItemWidth()
        {
            var itemWidth = Width;

            if (ItemsLayout is LinearItemsLayout listItemsLayout && listItemsLayout.Orientation == ItemsLayoutOrientation.Horizontal)
                itemWidth = (int)(Width - Context?.ToPixels(Carousel.PeekAreaInsets.Left) - Context?.ToPixels(Carousel.PeekAreaInsets.Right) - Context?.ToPixels(listItemsLayout.ItemSpacing));

            return itemWidth;
        }

        // Copied from the source Xamarin.Forms because of the accessibility levels
        private int GetItemHeight()
        {
            var itemHeight = Height;

            if (ItemsLayout is LinearItemsLayout listItemsLayout && listItemsLayout.Orientation == ItemsLayoutOrientation.Vertical)
                itemHeight = (int)(Height - Context?.ToPixels(Carousel.PeekAreaInsets.Top) - Context?.ToPixels(Carousel.PeekAreaInsets.Bottom) - Context?.ToPixels(listItemsLayout.ItemSpacing));

            return itemHeight;
        }
    }

    // Copied from the source Xamarin.Forms because of the accessibility levels
    internal class SizedItemContentView : ItemContentView
    {
        private readonly Func<int> _width;
        private readonly Func<int> _height;

        public SizedItemContentView(Context context, Func<int> width, Func<int> height)
            : base(context)
        {
            _width = width;
            _height = height;
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            if (Content == null)
            {
                SetMeasuredDimension(0, 0);
                return;
            }

            var targetWidth = _width();
            var targetHeight = _height();

            Content.Element.Measure(Context.FromPixels(targetWidth), Context.FromPixels(targetHeight),
                MeasureFlags.IncludeMargins);

            SetMeasuredDimension(targetWidth, targetHeight);
        }
    }

    internal class CustomItemsViewAdapter<TItemsView, TItemsViewSource> : ItemsViewAdapter<ItemsView, IItemsViewSource>
        where TItemsView : ItemsView
        where TItemsViewSource : IItemsViewSource

    {
        public CustomItemsViewAdapter(TItemsView itemsView, Func<Xamarin.Forms.View, Context, ItemContentView> createItemContentView = null) : base(itemsView, createItemContentView)
        {
        }

        // All magic happens here:
        public override void OnViewRecycled(Java.Lang.Object holder)
        {
            if (holder is TemplatedItemViewHolder templatedItemViewHolder)
            {
                templatedItemViewHolder.IsRecyclable = false;
            }

            // We need to remove this to remove the lag when switching tabs in MainPage, virtualization in CarouselView with 5 items is useless
            //base.OnViewRecycled(holder);
        }
    }
}