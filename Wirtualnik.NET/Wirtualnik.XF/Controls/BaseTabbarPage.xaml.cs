using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

//TODO: Add events for closing and opening menu an utilize them in AppShellPage to change icons
namespace Wirtualnik.XF.Controls
{
    [ContentProperty("Contents")]
    public partial class BaseTabbarPage : ContentView
    {
        private const uint duration = 250;
        private const double SheetHeight = 120;
        private const double threshold = SheetHeight * -0.4;

        public IList<View> Contents { get => pageContent.Children; }
        public bool OpenMenu { get; private set; }

        public BaseTabbarPage()
        {
            InitializeComponent();
        }

        //public static readonly BindableProperty OpenMenuProperty = BindableProperty.Create(nameof(OpenMenu), typeof(bool), typeof(BaseShellTab), default(bool), BindingMode.TwoWay);
        //public bool OpenMenu
        //{
        //    get => (bool)GetValue(OpenMenuProperty);
        //    set => SetValue(OpenMenuProperty, value);
        //}

        //protected override async void OnPropertyChanged(string? propertyName = null)
        //{
        //    base.OnPropertyChanged(propertyName);

        //    if (propertyName == OpenMenuProperty.PropertyName)
        //    {
        //        if (OpenMenu)
        //        {
        //            await OpenSheet();
        //        }
        //        else
        //        {
        //            await CloseSheet();
        //        }
        //    }
        //}

        public async Task OpenSheet()
        {
            await Task.WhenAll
            (
                menuBackgroundGrid.FadeTo(1, duration, Easing.CubicIn),
                menuPancakeView.FadeTo(1, duration / 2, Easing.CubicIn),
                menuPancakeView.TranslateTo(0, 0, duration, Easing.CubicIn)
            );

            sheetContainer.InputTransparent = menuBackgroundGrid.InputTransparent = false;
            OpenMenu = true;
        }

        public async Task CloseSheet()
        {
            await Task.WhenAll
            (
                menuBackgroundGrid.FadeTo(0, duration, Easing.CubicOut),
                menuPancakeView.FadeTo(0, duration / 2, Easing.CubicOut),
                menuPancakeView.TranslateTo(0, (SheetHeight + 60) * -1, duration, Easing.CubicOut)
            );

            sheetContainer.InputTransparent = menuBackgroundGrid.InputTransparent = true;
            OpenMenu = false;
        }

        private double currentPosition;
        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Running)
            {
                currentPosition = e.TotalY;

                if (currentPosition < 0)
                {
                    menuPancakeView.TranslationY = currentPosition;
                }
            }
            else if (e.StatusType == GestureStatus.Completed)
            {
                if (currentPosition > threshold)
                {
                    await OpenSheet();
                }
                else
                {
                    await CloseSheet();
                }
            }
        }
    }
}